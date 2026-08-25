using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sunflower API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();