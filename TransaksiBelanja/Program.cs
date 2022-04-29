using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TransaksiBelanja.AsyncDataService;
using TransaksiBelanja.Data;
using TransaksiBelanja.Helper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//maper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//EF Core
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).EnableSensitiveDataLogging());

//Maping
builder.Services.AddScoped<IShopping, ShoppingRepo>();
builder.Services.AddScoped<IProduct, ProductRepo>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

//jwt token
// var AppSettingSection = builder.Configuration.GetSection("AppSettings");
// builder.Services.Configure<AppSettings>(AppSettingSection);
// var AppSetting = AppSettingSection.Get<AppSettings>();
// var key = Encoding.ASCII.GetBytes(AppSetting.Secret);

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.RequireHttpsMetadata = false;
//     options.SaveToken = true;
//     options.TokenValidationParameters =
//         new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(key),
//             ValidateIssuer = false,
//             ValidateAudience = false

//         };
// });

//builder.Services.AddSingleton<IMessageAsyncClient, MessageAsyncClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
