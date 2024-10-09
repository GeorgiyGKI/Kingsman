using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Service.DataShaping;
using Shared.DTO;
using Shared.RequestFeatures;
using System.ComponentModel.Design;
using System.Dynamic;

namespace Service;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<ProductDto> _dataShaper;
    private readonly IProductLinks _productLinks;

    public ProductService(
        IRepositoryManager repository,
        IMapper mapper,
        IDataShaper<ProductDto> dataShaper,
        IProductLinks productLinks)
    {
        _repository = repository;
        _mapper = mapper;
        _dataShaper = dataShaper;
        _productLinks = productLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)> GetProductsAsync(
        LinkParameters linkParameters,
        bool trackChanges)
    {
        if (!linkParameters.ProductParameters.ValidPriceRange)
            throw new BadRequestException("Max price can't be less than min price");

        var productsWithMetaData = await _repository.Product.GetProductsAsync(linkParameters.ProductParameters, trackChanges);

        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
        var links = _productLinks.TryGenerateLinks(
            productDtos,
            linkParameters.ProductParameters.Fields,
            linkParameters.Context);


        return (linkResponse: links, metaData: productsWithMetaData.MetaData);
    }

    public async Task<ProductDto> GetProductAsync(Guid id, bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(id, trackChanges);

        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;
    }

    public async Task<ProductDto> CreateProductAsync(ProductForManipulationDto product)
    {
        var productEntity = _mapper.Map<Product>(product);

        _repository.Product.CreateProduct(productEntity);
        await _repository.SaveAsync();

        var productToReturn = _mapper.Map<ProductDto>(productEntity);

        return productToReturn;
    }

    public async Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var productEntities = await _repository.Product.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != productEntities.Count())
            throw new ArgumentOutOfRangeException();

        var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return productsToReturn;
    }

    public async Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollectionAsync
        (IEnumerable<ProductForManipulationDto> productCollection)
    {
        ArgumentNullException.ThrowIfNull(productCollection);

        var productEntities = _mapper.Map<IEnumerable<Product>>(productCollection);
        foreach (var product in productEntities)
        {
            _repository.Product.CreateProduct(product);
        }

        await _repository.SaveAsync();

        var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
        var ids = string.Join(",", productCollectionToReturn.Select(c => c.Id));

        return (products: productCollectionToReturn, ids: ids);
    }

    public async Task DeleteProductAsync(Guid productId, bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(productId, trackChanges);

        _repository.Product.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    public async Task UpdateProductAsync(
        Guid productId,
        ProductForManipulationDto productForUpdate,
        bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(productId, trackChanges);

        _mapper.Map(productForUpdate, product);
        await _repository.SaveAsync();
    }

    private async Task<Product> GetProductAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(product);


        return product;
    }
}
