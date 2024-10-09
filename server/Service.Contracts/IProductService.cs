using Entities.LinkModels;
using Entities.Models;
using Shared.DTO;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service.Contracts;
public interface IProductService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetProductsAsync
        (LinkParameters linkParameters, bool trackChanges);
    Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForManipulationDto product);
    Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollectionAsync(IEnumerable<ProductForManipulationDto> productCollection);
    Task DeleteProductAsync(Guid productId, bool trackChanges);
    Task UpdateProductAsync(Guid productId, ProductForManipulationDto productForUpdate, bool trackChanges);
}