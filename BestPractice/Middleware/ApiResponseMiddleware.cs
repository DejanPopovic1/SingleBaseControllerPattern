using BestPractice.Exceptions;
using BestPractice.Utilities;
using System.Net;

namespace BestPractice.Middleware;

public class ApiResponseMiddleware(RequestDelegate next, ILogger<ApiResponseMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ApiResponseMiddleware> _logger = logger;


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //Try executing the request delegate
            await _next(context);

            //Handle potential error responses
            await HandleApiResponse(context);

        }
        catch (Exception ex)
        {
            if (ex.GetType().IsSubclassOf(typeof(ApiException)))
            {
                await HandleApiResponse(context, (ApiException)ex);
            }
            else
            {
                await HandleApiResponse(context);
            }
        
        }
    }

    private async Task HandleApiResponse(HttpContext context, ApiException? ex = null)
    {
        if (context.Response.HasStarted)
        {
            if (ex is not null)
            {
                _logger.LogWarning(ex, "Unable to handle error response, context response already started");
            }
            return;
        }
        if (!IsApiContext(context))
        {
            if (ex is not null)
            {
                throw ex;
            }
            return;
        }

        _logger.LogError(ex, "An API exception occurred: {ErrorMessage}", ex?.Message ?? "Unknown Error");

        //Map specific metadata for various client error codes that might occur, to be used in the formatted error response
        switch (context.Response.StatusCode)
        {
            case (int)HttpStatusCode.BadRequest:
                await ApiResponseHelper.WriteErrorResponseAsync(context, HttpStatusCode.BadRequest, "Bad Request", ex);
                break;
            case (int)HttpStatusCode.Unauthorized:
                await ApiResponseHelper.WriteErrorResponseAsync(context, HttpStatusCode.Unauthorized, "Unauthorized", ex);
                break;
            case (int)HttpStatusCode.Forbidden:
                await ApiResponseHelper.WriteErrorResponseAsync(context, HttpStatusCode.Forbidden, "Forbidden", ex);
                break;
            case (int)HttpStatusCode.NotFound:
                await ApiResponseHelper.WriteErrorResponseAsync(context, HttpStatusCode.NotFound, "Not Found", ex);
                break;
        }
        if (context.Response.StatusCode >= 500 || ex is not null)
        {
            await ApiResponseHelper.WriteErrorResponseAsync(context, HttpStatusCode.InternalServerError, "Internal Server Error", ex);
            return;
        
        }
    }

    private static bool IsApiContext(HttpContext context)
    {
        return context.Request.Path.StartsWithSegments(new PathString("/api"));
    }



}
