using Entities.Models;
using Repository.Contracts;
using Repository;
using Microsoft.EntityFrameworkCore;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, bool includeRelatedEntities = false)
    {
        var productsQuery = FindAll(trackChanges);

        if (includeRelatedEntities)
        {
            productsQuery = productsQuery
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Color);
        }

        return await productsQuery
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Product> GetProductAsync(Guid productId, bool trackChanges, bool includeRelatedEntities = false)
    {
        var productQuery = FindByCondition(p => p.Id.Equals(productId), trackChanges);

        if (includeRelatedEntities)
        {
            productQuery = productQuery
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Color);
        }

        return await productQuery.SingleOrDefaultAsync();
    }

    public void CreateProduct(Product product) => Create(product);

    public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges, bool includeRelatedEntities = false)
    {
        var productsQuery = FindByCondition(x => ids.Contains(x.Id), trackChanges);

        if (includeRelatedEntities)
        {
            productsQuery = productsQuery
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Color);
        }

        return await productsQuery.ToListAsync();
    }

    public void DeleteProduct(Product product) => Delete(product);
}
