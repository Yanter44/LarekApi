using LarekApi;
using LarekApi.Interfaces;
using LarekApi.MiddleWares;
using LarekApi.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MikesPaging.AspNetCore;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MyMiddleWare>();
builder.Services.AddDbContext<ApplicationDb>(x => x.UseSqlServer("Server=DESKTOP-S9AIDDH\\SQLEXPRESS; Database=ApiLarok; Trusted_Connection=True; TrustServerCertificate=True"));
builder.Services.AddTransient<IProductService, SelleryService>();
builder.Services.AddTransient<IBuyerService, BuyerService>();
builder.Services.AddScoped<OrderNumberGenerationService>();
builder.Services.AddTransient<RequestDelegate>(_ => context => Task.CompletedTask);
builder.Services.AddPaging();
Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.Console()
             .CreateLogger();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<MyMiddleWare>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
