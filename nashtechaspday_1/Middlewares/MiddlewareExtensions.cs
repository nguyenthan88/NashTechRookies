namespace Middleware.Example;
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddlewareExtensions(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NashTechDay1CustomMiddleware>();
    }
}