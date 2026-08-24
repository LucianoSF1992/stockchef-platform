using MediatR;
using Microsoft.EntityFrameworkCore;
using StockChef.Application.Behaviors;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Infrastructure;
using StockChef.Infrastructure.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using StockChef.Application.Features.Categories.Validators;
using StockChef.Application.DTOs.Categories;
using StockChef.Api.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

// MediatR Pipeline Behaviors
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

// Controllers
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key não configurada.");

        var jwtIssuer = builder.Configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("JWT Issuer não configurado.");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();

builder.Services.AddFluentValidationAutoValidation();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Global Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Global Exception Handler
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();