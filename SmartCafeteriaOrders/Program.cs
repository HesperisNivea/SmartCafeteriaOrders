using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Dtos;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;
using SmartCafeteriaOrders.Repository.Repositories;
using SmartCafeteriaOrders.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                         ?? builder.Configuration.GetConnectionString("WebShopDbContext")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService<OrderDto>, OrderService>();
builder.Services.AddScoped<IOrderRepository<OrderEntity>, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



