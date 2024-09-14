using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

        // Ensure the database is created
        context.Database.EnsureCreated();

        // Check if there are any customers
        if (!context.Customers.Any())
        {
            SeedCustomers(context);
        }
    }

    private static void SeedCustomers(CustomerDbContext context)
    {
        var customers = new[]
        {
            new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1980, 1, 1) },
            new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1985, 5, 15) }
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();
    }
}