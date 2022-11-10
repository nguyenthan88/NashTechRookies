using Microsoft.EntityFrameworkCore;

using Test.Data;
using TestWebAPI.Repositories.Implements;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Implements;
using TestWebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7233",
                                "http://localhost:3000");
        });
});


builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<DBContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();