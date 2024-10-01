using Entities.Models;

namespace Repository.Contracts;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges);
    Task<Customer> GetCustomerAsync(string customerId, bool trackChanges);
    void CreateCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges);
    void DeleteCustomer(Customer customer);
}

