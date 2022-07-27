using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Project2.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BlackListTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public BlackListTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBlackListTokenService blackListTokenService)
        {
            string authorization = httpContext.Request.Headers["Authorization"];

            // If no authorization header found, nothing to process further
            if (string.IsNullOrEmpty(authorization))
            {
                await _next(httpContext);
                return;
            }

            string token = string.Empty;
            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = authorization.Substring("Bearer ".Length).Trim();
            }

            // If no token found, no further work possible
            if (string.IsNullOrEmpty(token))
            {
                HandleUnauthorized(httpContext);
                return;
            }

            // If token found, process further work
            if (await blackListTokenService.CheckTokenInBlackListAsync(token))
            {
                HandleUnauthorized(httpContext);
                return;
            }

            await _next(httpContext);
        }

        private void HandleUnauthorized(HttpContext httpContext)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
