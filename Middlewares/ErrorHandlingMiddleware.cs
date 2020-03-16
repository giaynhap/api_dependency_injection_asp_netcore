using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using System;
using System.Net;
using Newtonsoft.Json;
using apicore.Domain.Resources;
using apicore.Extensions;
namespace  apicore.MiddleWares
{
    
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context )
    {
        try
        {
            await next(context);
            await HandleHttpCodeAsync(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

     private static Task HandleHttpCodeAsync(HttpContext context )
    { 
        if (
            context.Response.StatusCode == (int)HttpStatusCode.Unauthorized ||
            context.Response.StatusCode == (int)HttpStatusCode.NotFound ||
            context.Response.StatusCode == (int)HttpStatusCode.BadRequest ||
            context.Response.StatusCode == (int)HttpStatusCode.InternalServerError
            ){
                var result = JsonConvert.SerializeObject(new ApiResponse<object>(){
                    code = context.Response.StatusCode,
                    message =  context.Response.StatusCode.statusCodeMessage()
                });
                context.Response.ContentType = "application/json"; 
                return context.Response.WriteAsync(result);
        }
      
        return null;
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    { 
         var result = JsonConvert.SerializeObject(new ApiResponse<string>(){
            code = (int)HttpStatusCode.InternalServerError,
            message = ex.Message,
            data = ex.InnerException.ToString()
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(result);
    }
}
}