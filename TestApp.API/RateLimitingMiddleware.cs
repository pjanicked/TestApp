namespace TestApp.API
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Limits the Get API to be executable every second based on the client's Ip Addresses
    /// </summary>
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ConcurrentDictionary<string, DateTime?> ApiCallsInMemory = new();

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var key = GetCurrentClientKey(context);

            var previousApiCall = GetPreviousApiCallByKey(key);
            if (previousApiCall != null)
            {

                if (DateTime.Now < previousApiCall.Value.AddSeconds(1))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    return;
                }
            }

            UpdateApiCallFor(key);

            await _next(context);
        }

        private void UpdateApiCallFor(string key)
        {
            ApiCallsInMemory.TryRemove(key, out _);
            ApiCallsInMemory.TryAdd(key, DateTime.Now);
        }

        private DateTime? GetPreviousApiCallByKey(string key)
        {
            ApiCallsInMemory.TryGetValue(key, out DateTime? value);
            return value;
        }

        private static string GetCurrentClientKey(HttpContext context)
        {
            var keys = new List<string>
            {
                context.Request.Path
            };

            keys.Add(GetClientIpAddress(context));

            return string.Join('_', keys);
        }

        private static string GetClientIpAddress(HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }
    }
}
