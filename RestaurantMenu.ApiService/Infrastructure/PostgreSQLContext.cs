using Microsoft.EntityFrameworkCore;
using RestaurantMenu.ApiService.Models;

namespace RestaurantMenu.ApiService.Infrastructure;

public class PostgreSQLContext : DbContext
{
    public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
