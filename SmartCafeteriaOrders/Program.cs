using Microsoft.AspNetCore.Http.HttpResults;
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


app.MapGet("/orders", async (IOrderService<OrderDto> orderService) =>
{
    return Results.Ok(await orderService.GetAllAsync());
});

app.MapGet("/orders/{id}", async (int id, IOrderService<OrderDto> orderService) =>
{
    var order = await orderService.GetOrderByIdAsync(id);
    return order is not null ? Results.Ok(order) : Results.NotFound();
});

app.MapPost("/orders", async (OrderDto orderDto, IOrderService<OrderDto> orderService) =>
{
    await orderService.AddAsync(orderDto);
    return Results.Ok();
});

app.MapPut("/orders/{id}", async (int id, OrderDto orderDto, IOrderService<OrderDto> orderService) =>
{
    await orderService.UpdateAsync(orderDto);
    return Results.Ok();
});

app.MapDelete("/orders/{id}", async (int id, IOrderService<OrderDto> orderService) =>
{
    await orderService.DeleteAsync(id);
    return Results.Ok();
});
