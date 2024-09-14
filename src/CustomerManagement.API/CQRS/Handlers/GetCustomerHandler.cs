using MediatR;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.API.CQRS.Queries;

namespace CustomerManagement.API.CQRS.Handlers;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(request.Id);
    }
}