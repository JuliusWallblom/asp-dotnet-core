using FluentValidation;
using MediatR;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.API.CQRS.Commands;
using CustomerManagement.Core.DTOs;

namespace CustomerManagement.API.CQRS.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerCommand> _validator;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IValidator<CreateCustomerCommand> validator)
    {
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        await _customerRepository.AddAsync(customer);

        return new CustomerDto
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Email = customer.Email
        };
    }
}