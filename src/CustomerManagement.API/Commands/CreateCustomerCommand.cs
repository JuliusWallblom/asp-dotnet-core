using MediatR;
using CustomerManagement.Core.DTOs;

namespace CustomerManagement.API.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
}