using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Repositories;
public interface IOrderRepository<T> : IBaseRepository<T> where T : class
{
    Task<OrderEntity?> GetOrderByIdAsync(int id);
}
public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository<OrderEntity>
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<OrderEntity?> GetOrderByIdAsync(int id)
    {
        return _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }
}
