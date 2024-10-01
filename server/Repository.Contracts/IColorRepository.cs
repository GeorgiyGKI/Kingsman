using Entities.Models;

namespace Repository.Contracts;

public interface IColorRepository
{
    Task<IEnumerable<Color>> GetAllColorsAsync(bool trackChanges);
    Task<Color> GetColorAsync(int colorId, bool trackChanges);
    void CreateColor(Color color);
    Task<IEnumerable<Color>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void DeleteColor(Color color);
}


