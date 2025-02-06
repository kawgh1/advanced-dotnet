namespace eCommerce.API.Middleware;

// may need to install the Microsoft.AspNetCore.Http.Abstractions package
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.GetType()}: {e.Message}");

            if (e.InnerException != null)
            {
                _logger.LogError($"{e.InnerException.GetType()}: {e.InnerException.Message}");
            }
            
            httpContext.Response.StatusCode = 500;
            
            await httpContext.Response.WriteAsJsonAsync(new { Message = e.Message, Type = e.GetType().ToString()});
            // throw;
        }
    }
}

// Extension method user to add middleware to the HTTP Request pipeline in Program.cs

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}