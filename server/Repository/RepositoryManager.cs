using Contracts;
using Repository.Contracts;
using Repository.RepositoryModels;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IColorRepository> _colorRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IOrderItemRepository> _orderItemRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IBrandRepository> _brandRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
        _colorRepository = new Lazy<IColorRepository>(() => new ColorRepository(repositoryContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        _orderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(repositoryContext));
    }

    public ICategoryRepository Category => _categoryRepository.Value;
    public IColorRepository Color => _colorRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;
    public IOrderItemRepository OrderItem => _orderItemRepository.Value;
    public IProductRepository Product => _productRepository.Value;
    public IBrandRepository Brand => _brandRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}