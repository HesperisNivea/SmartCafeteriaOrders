using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Dtos;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;
using SmartCafeteriaOrders.Repository.Repositories;
using SmartCafeteriaOrders.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("OrderDbContext");
}

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("SmartCafeteriaOrders")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService<OrderDto>, OrderService>();
builder.Services.AddScoped<IOrderRepository<OrderEntity>, OrderRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    dbContext.Database.Migrate();
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

app.MapPut("/orders", async (OrderDto orderDto, IOrderService<OrderDto> orderService) =>
{
    await orderService.UpdateAsync(orderDto);
    return Results.Ok();
});

app.MapDelete("/orders/{id}", async (int id, IOrderService<OrderDto> orderService) =>
{
    await orderService.DeleteAsync(id);
    return Results.Ok();
});

app.Run();