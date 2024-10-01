using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service;

internal sealed class CustomerService : ICustomerService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CustomerService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(bool trackChanges)
    {
        var customers = await _repository.Customer.GetAllCustomersAsync(trackChanges);

        var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

        return customersDto;
    }

    public async Task<CustomerDto> GetCustomerAsync(string id, bool trackChanges)
    {
        var customer = await GetCustomerAndCheckIfItExists(id, trackChanges);

        var customerDto = _mapper.Map<CustomerDto>(customer);

        return customerDto;
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerForManipulationDto customer)
    {
        var customerEntity = _mapper.Map<Customer>(customer);

        _repository.Customer.CreateCustomer(customerEntity);
        await _repository.SaveAsync();

        var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);

        return customerToReturn;
    }

    public async Task<IEnumerable<CustomerDto>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var customerEntities = await _repository.Customer.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != customerEntities.Count())
            throw new ArgumentOutOfRangeException();

        var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customerEntities);

        return customersToReturn;
    }

    public async Task<(IEnumerable<CustomerDto> customers, string ids)> CreateCustomerCollectionAsync
        (IEnumerable<CustomerForManipulationDto> customerCollection)
    {
        ArgumentNullException.ThrowIfNull(customerCollection);

        var customerEntities = _mapper.Map<IEnumerable<Customer>>(customerCollection);
        foreach (var customer in customerEntities)
        {
            _repository.Customer.CreateCustomer(customer);
        }

        await _repository.SaveAsync();

        var customerCollectionToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customerEntities);
        var ids = string.Join(",", customerCollectionToReturn.Select(c => c.Id));

        return (customers: customerCollectionToReturn, ids);
    }

    public async Task DeleteCustomerAsync(string customerId, bool trackChanges)
    {
        var customer = await GetCustomerAndCheckIfItExists(customerId, trackChanges);

        _repository.Customer.DeleteCustomer(customer);
        await _repository.SaveAsync();
    }

    public async Task UpdateCustomerAsync(
        string customerId,
        CustomerForManipulationDto customerForUpdate,
        bool trackChanges)
    {
        var customer = await GetCustomerAndCheckIfItExists(customerId, trackChanges);

        _mapper.Map(customerForUpdate, customer);
        await _repository.SaveAsync();
    }

    private async Task<Customer> GetCustomerAndCheckIfItExists(string id, bool trackChanges)
    {
        var customer = await _repository.Customer.GetCustomerAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(customer);

        return customer;
    }
}
