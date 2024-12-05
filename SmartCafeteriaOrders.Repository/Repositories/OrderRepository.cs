using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Repositories;
public interface IOrderRepository<T> : IBaseRepository<T> where T : class
{
    Task<T> GetOrderByIdAsync(int id);
}
public class OrderRepository(OrderDbContext context) : BaseRepository<OrderEntity>(context), IOrderRepository<OrderEntity>
{
    

    public async Task<OrderEntity> GetOrderByIdAsync(int id)
    {
        return await context.Orders.Include(x => x.ProductIds).FirstOrDefaultAsync(x => x.Id == id);
    }
}
