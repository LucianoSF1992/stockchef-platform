using MediatR;
using Microsoft.EntityFrameworkCore;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Infrastructure;
using StockChef.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// SQL Server
builder.Services.AddDbContext<StockChefDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection - Infrastructure
builder.Services.AddInfrastructure();

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateCategoryCommand).Assembly);
});

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
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

app.UseAuthorization();

app.MapControllers();

app.Run();