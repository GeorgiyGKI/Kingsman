using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service;

internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CategoryService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
    {
        var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges);

        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoriesDto;
    }

    public async Task<CategoryDto> GetCategoryAsync(int id, bool trackChanges)
    {
        var category = await GetCategoryAndCheckIfItExists(id, trackChanges);

        var categoryDto = _mapper.Map<CategoryDto>(category);

        return categoryDto;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryForManipulationDto category)
    {
        var categoryEntity = _mapper.Map<Category>(category);

        _repository.Category.CreateCategory(categoryEntity);
        await _repository.SaveAsync();

        var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

        return categoryToReturn;
    }

    public async Task<IEnumerable<CategoryDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var categoryEntities = await _repository.Category.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != categoryEntities.Count())
            throw new ArgumentOutOfRangeException();

        var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);

        return categoriesToReturn;
    }

    public async Task<(IEnumerable<CategoryDto> categories, string ids)> CreateCategoryCollectionAsync
        (IEnumerable<CategoryForManipulationDto> categoryCollection)
    {
        ArgumentNullException.ThrowIfNull(categoryCollection);

        var categoryEntities = _mapper.Map<IEnumerable<Category>>(categoryCollection);
        foreach (var category in categoryEntities)
        {
            _repository.Category.CreateCategory(category);
        }

        await _repository.SaveAsync();

        var categoryCollectionToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
        var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.Id));

        return (categories: categoryCollectionToReturn, ids);
    }

    public async Task DeleteCategoryAsync(int categoryId, bool trackChanges)
    {
        var category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

        _repository.Category.DeleteCategory(category);

        await _repository.SaveAsync();
    }

    public async Task UpdateCategoryAsync(
        int categoryId,
        CategoryForManipulationDto categoryForUpdate,
        bool trackChanges)
    {
        var category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

        _mapper.Map(categoryForUpdate, category);

        await _repository.SaveAsync();
    }

    private async Task<Category> GetCategoryAndCheckIfItExists(int id, bool trackChanges)
    {
        var category = await _repository.Category.GetCategoryAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(category);

        return category;
    }
}

