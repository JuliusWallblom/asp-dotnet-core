using MediatR;
using CustomerManagement.Core.Entities;

namespace CustomerManagement.API.Queries;

public record GetAllCustomersQuery() : IRequest<IEnumerable<Customer>>;