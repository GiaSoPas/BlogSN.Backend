using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using BlogSN.Backend.Exceptions;
using Microsoft.AspNetCore.Http;


namespace BlogSN.Backend.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            context.Response.ContentType = "application/json";

            switch (error)
            {
                case NotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await context.Response.WriteAsync(result);
        }
    }
}