using Shared.DTO;

namespace Service.Contracts;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
    Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForManipulationDto product);
    Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollectionAsync(IEnumerable<ProductForManipulationDto> productCollection);
    Task DeleteProductAsync(Guid productId, bool trackChanges);
    Task UpdateProductAsync(Guid productId, ProductForManipulationDto productForUpdate, bool trackChanges);
}