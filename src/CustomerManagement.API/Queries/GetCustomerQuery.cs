using MediatR;
using CustomerManagement.Core.Entities;

namespace CustomerManagement.API.Queries;

public record GetCustomerQuery(int Id) : IRequest<Customer>;