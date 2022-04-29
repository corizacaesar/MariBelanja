using Microsoft.EntityFrameworkCore;
using TransaksiBelanja.AsyncDataService;
using TransaksiBelanja.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//maper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//EF Core
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).EnableSensitiveDataLogging());

//Maping
builder.Services.AddScoped<IShopping, ShoppingRepo>();
builder.Services.AddScoped<IProduct, ProductRepo>();

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
