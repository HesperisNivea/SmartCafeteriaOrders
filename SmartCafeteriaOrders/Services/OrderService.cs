using SmartCafeteriaOrders.Dtos;
using SmartCafeteriaOrders.Repository.Entities;
using SmartCafeteriaOrders.Repository.Repositories;

namespace SmartCafeteriaOrders.Services;

interface IOrderService<T> where T : class
{
    Task AddAsync(T dto);
    Task UpdateAsync(T dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetOrderByIdAsync(int id);
}

public class OrderService(IOrderRepository<OrderEntity> orders) : IOrderService<OrderDto>
{
    public async Task AddAsync(OrderDto dto)
    {
        var order = new OrderEntity
        {
            TotalPrice = dto.TotalPrice,
        };
        await orders.AddAsync(order);
    }

    public async Task UpdateAsync(OrderDto dto)
    {
        var order = new OrderEntity
        {
            Id = dto.Id,
            TotalPrice = dto.TotalPrice
        };

        await orders.UpdateAsync(order);
    }

    public async Task DeleteAsync(int id)
    {
        await orders.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var result = await orders.GetAllAsync();
        return result.Select(order => new OrderDto
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice
        });
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var order = await orders.GetOrderByIdAsync(id);
        return order is not null ? new OrderDto
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice
        } : null;

    }
}