using Shared.DTO;

namespace Service.Contracts;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(bool trackChanges);
    Task<CustomerDto> GetCustomerAsync(string id, bool trackChanges);
    Task<CustomerDto> CreateCustomerAsync(CustomerForManipulationDto customer);
    Task<IEnumerable<CustomerDto>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges);
    Task<(IEnumerable<CustomerDto> customers, string ids)> CreateCustomerCollectionAsync(IEnumerable<CustomerForManipulationDto> customerCollection);
    Task DeleteCustomerAsync(string customerId, bool trackChanges);
    Task UpdateCustomerAsync(string customerId, CustomerForManipulationDto customerForUpdate, bool trackChanges);
}
