namespace Service.Contracts;
public interface IServiceManager
{
    IBrandService BrandService { get; }
    ICategoryService CategoryService { get; }
    IColorService ColorService { get; }
    ICustomerService CustomerService { get; }
    IOrderItemService OrderItemService { get; }
    IOrderService OrderService { get; }
    IProductService ProductService { get; }
}
