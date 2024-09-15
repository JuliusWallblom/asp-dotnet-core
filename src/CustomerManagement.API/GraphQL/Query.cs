using CustomerManagement.API.Queries;
using CustomerManagement.Core.DTOs;
using CustomerManagement.Core.Entities;
using HotChocolate;
using MediatR;

namespace CustomerManagement.API.GraphQL;

public class Query
{
    /// <summary>
    /// Retrieves a single customer by their ID.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer details.</returns>
    public async Task<IEnumerable<CustomerDto>> GetCustomers([Service] IMediator mediator)
    {
        var customers = await mediator.Send(new GetAllCustomersQuery());
        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            FullName = $"{c.FirstName} {c.LastName}",
            Email = c.Email
        });
    }

    /// <summary>
    /// Retrieves a list of all customers.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    public async Task<CustomerDto> GetCustomer([Service] IMediator mediator, int id)
    {
        var customer = await mediator.Send(new GetCustomerQuery(id));
        return new CustomerDto
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Email = customer.Email
        };
    }
}