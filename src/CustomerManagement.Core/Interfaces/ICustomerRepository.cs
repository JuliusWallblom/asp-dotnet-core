using CustomerManagement.Core.Entities;

namespace CustomerManagement.Core.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}