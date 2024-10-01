using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.RepositoryModels;

internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateCategory(Category category) => Create(category);

    public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToListAsync();

    public void DeleteCategory(Category category) => Delete(category);
}


