﻿global using Autofac;
global using Core.AppResults;
global using Core.AspNet.Endpoints;
global using Core.AspNet.Extensions;
global using Core.AspNet.Result;
global using Core.Autofac;
global using Core.EntityFramework;
global using Core.EntityFramework.Context;
global using Core.EntityFramework.Repository;
global using Core.EntityFramework.ServiceDefault;
global using Core.Events.DomainEvents;
global using Core.Events.EventStore;
global using Core.IntegrationEvents.IntegrationEvents;
global using Core.Kafka;
global using Core.Kafka.Producers;
global using Core.Marten;
global using Core.MediaR;
global using Core.SharedKernel;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Ordering.API.Application.Common.Abstractions;
global using Ordering.API.Application.Common.Constants;
global using Ordering.API.Application.Dto.Order;
global using Ordering.API.Application.IntegrationEvents;
global using Ordering.API.Application.Services;
global using Ordering.API.Domain.OrderAggregate;
global using Ordering.API.Domain.OrderAggregate.Events;
global using Ordering.API.Infrastructure;
global using Ordering.API.Presentation.Extensions;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Reflection;
global using System.Text.Json.Serialization;
global using Order = Ordering.API.Domain.OrderAggregate.Order;