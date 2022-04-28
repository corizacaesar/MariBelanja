using Data;
using Data.Helper;
using Data.Interface;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//EF Core
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(
        builder.Configuration.GetConnectionString("MyConnection")).EnableSensitiveDataLogging());

//Maping
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IShipping, ShippingRepo>();
builder.Services.AddScoped<IShopping, ShoppingRepo>();

//JWT
var AppSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(AppSettingSection);
var AppSetting = AppSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(AppSetting.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false

        };
});

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
