using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.DTO;

namespace Service;

internal sealed class BrandService : IBrandService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public BrandService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges)
    {
        var companies = await _repository.Brand.GetAllBrandsAsync(trackChanges);

        var brandsDto = _mapper.Map<List<BrandDto>>(companies);

        return brandsDto;
    }

    public async Task<BrandDto> GetBrandAsync(int id, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(id, trackChanges);

        var brandDto = _mapper.Map<BrandDto>(brand);
        return brandDto;
    }

    public async Task<BrandDto> CreateBrandAsync(BrandForManipulationDto brand)
    {
        var brandEntity = _mapper.Map<Brand>(brand);

        _repository.Brand.CreateBrand(brandEntity);
        await _repository.SaveAsync();

        var brandToReturn = _mapper.Map<BrandDto>(brandEntity);

        return brandToReturn;
    }

    public async Task<IEnumerable<BrandDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        if (ids is null)
            throw new ArgumentNullException(nameof(ids));

        var brandEntities = await _repository.Brand.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != brandEntities.Count())
            throw new ArgumentOutOfRangeException();

        var brandsToReturn = _mapper.Map<IEnumerable<BrandDto>>(brandEntities);

        return brandsToReturn;
    }

    public async Task<(IEnumerable<BrandDto> brands, string ids)> CreateBrandCollectionAsync
        (IEnumerable<BrandForManipulationDto> brandCollection)
    {
        if (brandCollection is null)
            throw new ArgumentNullException();

        var brandEntities = _mapper.Map<IEnumerable<Brand>>(brandCollection);
        foreach (var Brand in brandEntities)
        {
            _repository.Brand.CreateBrand(Brand);
        }

        await _repository.SaveAsync();

        var brandCollectionToReturn = _mapper.Map<IEnumerable<BrandDto>>(brandEntities);
        var ids = string.Join(",", brandCollectionToReturn.Select(c => c.Id));

        return (brands: brandCollectionToReturn, ids);
    }

    public async Task DeleteBrandAsync(int brandId, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(brandId, trackChanges);

        _repository.Brand.DeleteBrand(brand);
        await _repository.SaveAsync();
    }

    public async Task UpdateBrandAsync(
        int brandId,
        BrandForManipulationDto brandForUpdate,
        bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(brandId, trackChanges);

        _mapper.Map(brandForUpdate, brand);
        await _repository.SaveAsync();
    }

    private async Task<Brand> GetBrandAndCheckIfItExists(int id, bool trackChanges)
    {
        var brand = await _repository.Brand.GetBrandAsync(id, trackChanges);
        if (brand is null)
            throw new ArgumentNullException();

        return brand;
    }
}

