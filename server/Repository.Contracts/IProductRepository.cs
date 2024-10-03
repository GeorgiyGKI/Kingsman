using Entities.Models;
using Shared.RequestFeatures;

namespace Repository.Contracts;

public interface IProductRepository
{
    Task<PagedList<Product>> GetProductsAsync(
        ProductParameters productParameters,
        bool trackChanges,
        bool includeRelatedEntities = false
        );
    Task<Product> GetProductAsync(Guid productId, bool trackChanges, bool includeRelatedEntities = false);
    void CreateProduct(Product product);
    Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges, bool includeRelatedEntities = false);
    void DeleteProduct(Product product);
}


