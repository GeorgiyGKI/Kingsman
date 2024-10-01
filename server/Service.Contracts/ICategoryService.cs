using Shared.DTO;

namespace Service.Contracts;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
    Task<CategoryDto> GetCategoryAsync(int id, bool trackChanges);
    Task<CategoryDto> CreateCategoryAsync(CategoryForManipulationDto category);
    Task<IEnumerable<CategoryDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    Task<(IEnumerable<CategoryDto> categories, string ids)> CreateCategoryCollectionAsync(IEnumerable<CategoryForManipulationDto> categoryCollection);
    Task DeleteCategoryAsync(int categoryId, bool trackChanges);
    Task UpdateCategoryAsync(int categoryId, CategoryForManipulationDto categoryForUpdate, bool trackChanges);
}