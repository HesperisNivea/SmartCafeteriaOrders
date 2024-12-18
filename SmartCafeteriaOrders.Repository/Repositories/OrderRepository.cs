using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Repositories;
public interface IOrderRepository<T> : IBaseRepository<T> where T : class
{
    Task<OrderEntity?> GetOrderByIdAsync(int id);
}
public class OrderRepository(OrderDbContext context) : BaseRepository<OrderEntity>(context), IOrderRepository<OrderEntity>
{
    public Task<OrderEntity?> GetOrderByIdAsync(int id)
    {
        return context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }
}
