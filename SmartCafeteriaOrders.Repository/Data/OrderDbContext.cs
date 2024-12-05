using Microsoft.EntityFrameworkCore;
using SmartCafeteriaOrders.Repository.Entities;

namespace SmartCafeteriaOrders.Repository.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext
{
    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}