﻿using Core.Events.EventStore;
using Core.Marten.OpenTelemetry;
using Core.Marten.Repository;
using Core.SharedKernel;
using Marten;
using Marten.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

namespace Core.Marten
{
    public static class Config
    {
        private const string DefaultConfigKey = "EventStore";

        public static IServiceCollection AddMarten(this IServiceCollection services, IConfiguration configuration)
        {
            var martenOptions = configuration.GetRequiredSection(DefaultConfigKey).Get<MartenConnection>();
            if (martenOptions == null) throw new ArgumentNullException(nameof(martenOptions));

            services.AddMarten(options =>
            {
                options.Connection(martenOptions.ConnectionString);
                options.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;

                options.Events.DatabaseSchemaName = martenOptions.WriteSchema;
                //options.DatabaseSchemaName = martenOptions.ReadSchema;

                options.UseSystemTextJsonForSerialization();

                options.Events.MetadataConfig.CausationIdEnabled = true;
                options.Events.MetadataConfig.CorrelationIdEnabled = true;
                options.Events.MetadataConfig.HeadersEnabled = true;

                options.OpenTelemetry.TrackConnections = TrackLevel.Normal;
                options.OpenTelemetry.TrackEventCounters();
            })
            .UseLightweightSessions();

            return services;
        }

        public static IServiceCollection AddMartenRepository<T>(
            this IServiceCollection services,
            bool withTelemetry = true
        ) where T : AggregateRoot<Guid>
        {
            services.AddScoped<IEventStoreRepository<T>, MartenRepository<T>>();

            if(withTelemetry)
                services.Decorate<IEventStoreRepository<T>>(
                    (inner, sp) => new MartenRepositoryWithTelemetryDecorator<T>(
                        inner,
                        sp.GetRequiredService<IDocumentSession>()
                    )
                );          

            return services;
        }

        public static WebApplicationBuilder AddMartenOpenTelemetry(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenTelemetry()
                .WithTracing(tracing =>
                {
                    tracing.AddSource(MartenActivityScope.ActivitySourceName);
                });

            return builder;
        }
    }
}