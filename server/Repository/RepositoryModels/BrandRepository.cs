using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System.ComponentModel.Design;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.RepositoryModels;

internal sealed class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    public BrandRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Brand> GetBrandAsync(int brandId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(brandId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateBrand(Brand brand) => Create(brand);

    public async Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToListAsync();

    public void DeleteBrand(Brand brand) => Delete(brand);
}


