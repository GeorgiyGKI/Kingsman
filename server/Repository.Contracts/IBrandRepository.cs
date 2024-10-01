using Entities.Models;

namespace Repository.Contracts;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges);
    Task<Brand> GetBrandAsync(int brandId, bool trackChanges);
    void CreateBrand(Brand brand);
    Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void DeleteBrand(Brand brand);
}

