using Middleware.Example;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMiddlewareExtensions();
app.Run();
