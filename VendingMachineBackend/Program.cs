using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;
using VendingMachineBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<VendingMachineContext>(opt =>
    opt.UseInMemoryDatabase("VendingMachine"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services and repositories
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IDepositService, DepositService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IDepositRepository, DepositRepository>();

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
public partial class Program { }