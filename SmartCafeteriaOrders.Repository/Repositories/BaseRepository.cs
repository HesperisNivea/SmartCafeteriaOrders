using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Data;

namespace SmartCafeteriaOrders.Repository.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}

public class BaseRepository<T>(OrderDbContext context) : IBaseRepository<T> where T : class
{
    public async Task AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        context.Remove(id);
        await context.SaveChangesAsync();
    }
   

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await context.Set<T>().AsNoTracking().ToListAsync();
        return result;
    }
}