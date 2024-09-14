using MediatR;
using CustomerManagement.Core.Entities;

namespace CustomerManagement.API.CQRS.Queries;

public record GetAllCustomersQuery() : IRequest<IEnumerable<Customer>>;