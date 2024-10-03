using Entities.Models;
using Repository.Contracts;
using Repository;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<PagedList<Product>> GetProductsAsync(
        ProductParameters productParameters,
        bool trackChanges,
        bool includeRelatedEntities = false)
    {
        var productsQuery = FindAll(trackChanges)
            .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
            .Search(productParameters.SearchTerm)
            .Sort(productParameters.OrderBy);

        if (includeRelatedEntities)
        {
            productsQuery = productsQuery
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Color);
        }


        var products = await productsQuery.ToListAsync();
        return  PagedList<Product>.ToPagedList(
            products,
            productParameters.PageNumber,
            productParameters.PageSize);
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
