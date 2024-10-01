using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IBrandService> _brandService;
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IColorService> _colorService;
    private readonly Lazy<ICustomerService> _customerService;
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<IOrderItemService> _orderItemService;
    private readonly Lazy<IProductService> _productService;

    public ServiceManager(
        IRepositoryManager repositoryManager,
        IMapper mapper
        )
    {
        _brandService = new Lazy<IBrandService>(() =>
          new BrandService(repositoryManager, mapper));

        _categoryService = new Lazy<ICategoryService>(() =>
          new CategoryService(repositoryManager, mapper));

        _colorService = new Lazy<IColorService>(() =>
          new ColorService(repositoryManager, mapper));

        _customerService = new Lazy<ICustomerService>(() =>
          new CustomerService(repositoryManager, mapper));

        _orderService = new Lazy<IOrderService>(() =>
          new OrderService(repositoryManager, mapper));

        _orderItemService = new Lazy<IOrderItemService>(() =>
          new OrderItemService(repositoryManager, mapper));

        _productService = new Lazy<IProductService>(() =>
          new ProductService(repositoryManager, mapper));
    }

    public IBrandService BrandService => _brandService.Value;
    public ICategoryService CategoryService => _categoryService.Value;
    public IColorService ColorService => _colorService.Value;
    public ICustomerService CustomerService => _customerService.Value;
    public IOrderService OrderService => _orderService.Value;
    public IOrderItemService OrderItemService => _orderItemService.Value;
    public IProductService ProductService => _productService.Value;
}

