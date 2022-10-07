using System.Text;
namespace Middleware.Example;
public class NashTechDay1CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public NashTechDay1CustomMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnvironment)
    {
        _next = next;
        _hostingEnvironment = hostingEnvironment;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var stringBuilder = new StringBuilder();
        var directoryPath = Path.Combine(_hostingEnvironment.ContentRootPath, "LogFiles");

        stringBuilder.Append("Schema: " + context.Request.Scheme);
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("Host: " + context.Request.Host);
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("Path: " + context.Request.Path);
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("QueryString: " + context.Request.QueryString);
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("RequestBody: " + context.Request.Body);

        LoggingHelper.WriteToFile(directoryPath, "RequestLog.txt", stringBuilder.ToString());
        await Task.Run(
          async () =>
          {
              await context.Response.WriteAsync("All Information Log To File: RequestLog.txt ");
          }
        );
    }
}