using CustomerManagement.API.CQRS.Commands;
using CustomerManagement.Core.DTOs;
using HotChocolate;
using MediatR;
using FluentValidation;

namespace CustomerManagement.API.GraphQL;

public class Mutation
{
    public async Task<OperationResult<CustomerDto>> CreateCustomer(
        [Service] IMediator mediator,
        string firstName,
        string lastName,
        string email)
    {
        try
        {
            var command = new CreateCustomerCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var result = await mediator.Send(command);
            return new OperationResult<CustomerDto> { Successful = true, Data = result };
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new UserError(e.ErrorMessage, e.PropertyName)).ToList();
            return new OperationResult<CustomerDto> { Successful = false, Errors = errors };
        }
    }
}