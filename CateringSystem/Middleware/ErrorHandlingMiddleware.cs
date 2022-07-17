using CateringSystem.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CateringSystem.Middleware
{
    public class ErrorHandlingMiddleware: IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(BadRequestException badRequestExc)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestExc.Message);
            }
            catch(ForbidException forbidExc)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbidExc.Message);
            }
            catch(NotFoundException notFoundExc)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundExc.Message);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.ToString());
            }
        }
    }
}
