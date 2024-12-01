﻿using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Core.EntityFramework
{
    public static class Configs
    {
        public static OpenTelemetryBuilder AddEFCoreOpenTelemetry(this OpenTelemetryBuilder builder)
        {
            builder
                .WithTracing(tracing =>
                {
                    tracing.AddEntityFrameworkCoreInstrumentation();
                });

            return builder;
        }
    }
}
