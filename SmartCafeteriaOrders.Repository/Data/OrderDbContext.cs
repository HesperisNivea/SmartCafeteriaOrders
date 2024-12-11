using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Data;

public class OrderDbContext : DbContext
{
    
    public DbSet<OrderEntity> Orders { get; set; }
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<OrderEntity>().HasKey(o => o.Id);
    }

}