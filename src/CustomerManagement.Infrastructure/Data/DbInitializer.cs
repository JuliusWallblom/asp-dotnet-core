using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CustomerDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
        {
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            context.Customers.AddRange(
                new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1980, 1, 1) },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1985, 5, 15) }
            );

            context.SaveChanges();
        }
    }
}