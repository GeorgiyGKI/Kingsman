using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.RepositoryModels;

internal sealed class ColorRepository : RepositoryBase<Color>, IColorRepository
{
    public ColorRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Color>> GetAllColorsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Color> GetColorAsync(int colorId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(colorId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateColor(Color color) => Create(color);

    public async Task<IEnumerable<Color>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToListAsync();

    public void DeleteColor(Color color) => Delete(color);
}


