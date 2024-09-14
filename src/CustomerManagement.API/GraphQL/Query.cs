using CustomerManagement.API.CQRS.Queries;
using CustomerManagement.Core.DTOs;
using CustomerManagement.Core.Entities;
using HotChocolate;
using MediatR;

namespace CustomerManagement.API.GraphQL;

public class Query
{
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