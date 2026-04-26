namespace TodoList.Middleware;

public class LoggingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");
        await next(context);
        Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
    }
}