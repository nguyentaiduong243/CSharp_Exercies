using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace CustomMiddlewera
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var sw = new Stopwatch();
            sw.Start();
            var name = httpContext.Request.Query["name"];
            if (!String.IsNullOrWhiteSpace(name) )
            {
                httpContext.Request.Headers.Add("headerKey","headerValue");
            }
            await httpContext.Response.WriteAsync($"<p>{httpContext.Request.Scheme} {httpContext.Request.Path} {httpContext.Request.Host} {httpContext.Request.Method}</p>");
            await httpContext.Response.WriteAsync($" <h2>The time current request took: {sw.ElapsedMilliseconds}</h2>");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}