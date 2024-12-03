﻿using Core.AspNet.Results;
using Core.AppResults;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Core.AspNet.Endpoints
{
    public static class FastEndpointConfigs
    {
        /// <summary>
        /// Handle validation failure (400 code), and serialize dto
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Config DefaultResponseConfigs(this Config config)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            config.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
            {
                return new HttpErrorResult((HttpStatusCode)statusCode,
                    failures.Select(e => new ErrorDetail(e.PropertyName, e.ErrorMessage)));
            };

            config.Serializer.ResponseSerializer = (reposnse, dto, cType, jsonContext, ct) =>
            {
                reposnse.ContentType = cType;
                return reposnse.WriteAsync(JsonSerializer.Serialize(dto, jsonSerializerOptions), ct);
            };

            return config;
        }
    }
}
