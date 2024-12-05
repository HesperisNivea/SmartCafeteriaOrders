using SmartCafeteriaOrders.Dtos;

namespace SmartCafeteriaOrders.Services;

interface IOrderService<T> where T : class
{
    Task AddAsync(T dto);
    Task UpdateAsync(T dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetOrderByIdAsync(int id);
}

public class OrderService: IOrderService<OrderDto>
{
    public Task AddAsync(OrderDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}