using Middleware.Example;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "");

app.UseMiddlewareExtensions();

app.Run();
