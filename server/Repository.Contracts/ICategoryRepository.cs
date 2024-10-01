using Entities.Models;

namespace Repository.Contracts;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
    Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);
    void CreateCategory(Category category);
    Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void DeleteCategory(Category category);
}

