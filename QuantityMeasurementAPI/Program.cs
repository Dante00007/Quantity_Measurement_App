using QuantityMeasurementAppModelLayer.Util;
using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepoLayer.Context;
using QuantityMeasurementAppRepoLayer.Interface;
using QuantityMeasurementAppRepoLayer.Repository;


using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QuantityMeasurementAPI.Middleware;
using Microsoft.EntityFrameworkCore;


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = new JwtSettings();

builder.Configuration.GetSection("Jwt").Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);


builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();

// // Repos
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();

//OLD
builder.Services.AddScoped<IMeasurementHistoryRepository, MeasurementHistoryRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//for ADO
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
AppConfig.ConnectionString = connectionString;

// for EF
builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(connectionString);
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.Run();


