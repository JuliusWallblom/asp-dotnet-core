using MediatR;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.API.CQRS.Queries;

namespace CustomerManagement.API.CQRS.Handlers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetAllAsync();
    }
}