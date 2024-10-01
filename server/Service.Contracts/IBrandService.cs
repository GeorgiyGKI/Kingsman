using Shared.DTO;

namespace Service;
public interface IBrandService
{
    Task<BrandDto> CreateBrandAsync(BrandForManipulationDto brand);
    Task<(IEnumerable<BrandDto> brands, string ids)> CreateBrandCollectionAsync(IEnumerable<BrandForManipulationDto> brandCollection);
    Task DeleteBrandAsync(int brandId, bool trackChanges);
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges);
    Task<BrandDto> GetBrandAsync(int id, bool trackChanges);
    Task<IEnumerable<BrandDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    Task UpdateBrandAsync(int brandId, BrandForManipulationDto brandForUpdate, bool trackChanges);
}