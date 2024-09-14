using CustomerManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);
    }
}