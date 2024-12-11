using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Data;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Repositories;
public interface IOrderRepository<T> : IBaseRepository<T> where T : class
{
 
}
public class OrderRepository(OrderDbContext context) : BaseRepository<OrderEntity>(context), IOrderRepository<OrderEntity>
{
    
}
