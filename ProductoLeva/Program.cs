using AuthApiVideoGame.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProductoLeva.Data;
using ProductoLeva.Interfaces;
using ProductoLeva.Interfaz;
using ProductoLeva.Middleware;
using ProductoLeva.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var jwtKey = builder.Configuration["Jwt:key"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Iusser"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductoContext>();
builder.Services.AddScoped<IAuth, Auth>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddOpenApi();

// Note: JwtService is stateless and can be registered as Scoped or Singleton depending on needs. If it only reads configuration, consider AddSingleton instead of AddScoped for a small performance benefit; however AddScoped is safe.

// Also ensure you have the using for the JwtService and IJwtService namespaces at top of file:
// using ProductoLeva.Interfaz;
// using AuthApiVideoGame.Services;","explanation":"Register IJwtService implementation (JwtService) so DI can resolve it when constructing AuthService. Added comments about singleton option and required using directives."}```json въз```}```json I'm sorry, there was an error. I'll correct and retry.```

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
