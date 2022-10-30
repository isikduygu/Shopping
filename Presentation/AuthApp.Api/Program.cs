using AuthApp.Application;
using AuthApp.Infrastructure;
using AuthApp.Infrastructure.Services.Storage.Azure;
using AuthApp.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
//builder.Services.AddStorage();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new() // token� validare ediyoruz.
        {
            ValidateAudience = true,  // olu�turulacak token� kimlerin hangi sitelerin kullanca��n� belirliyoruz
            ValidateIssuer = true, // kimin da��tt���n� �rn: ben�m api
            ValidateLifetime = true, // s�resini kontrol eder
            ValidateIssuerSigningKey = true, // uygulamam�za ait bir de�er oldu�unu ifade eden security key 

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator =(notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false // expires olduktan hemen sonra oturum sona ermesi i�in (refresh yapmadan)
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();
