using MediatR;
using CustomerManagement.Core.Entities;

namespace CustomerManagement.API.CQRS.Queries;

public record GetCustomerQuery(int Id) : IRequest<Customer>;