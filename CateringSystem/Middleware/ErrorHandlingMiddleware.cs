using CateringSystem.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CateringSystem.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(BadRequestException badRequestExc)
            {
                context.Response.StatusCode = 400;
            }
            catch(ForbidException forbidExc)
            {
                context.Response.StatusCode = 403;
            }
            catch(NotFoundException notFoundExc)
            {
                context.Response.StatusCode = 404;
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.ToString());
            }
        }
    }
}
