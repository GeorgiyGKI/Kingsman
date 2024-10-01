using Shared.DTO;

namespace Service.Contracts;
public interface IColorService
{
    Task<IEnumerable<ColorDto>> GetAllColorsAsync(bool trackChanges);
    Task<ColorDto> GetColorAsync(int id, bool trackChanges);
    Task<ColorDto> CreateColorAsync(ColorForManipulationDto color);
    Task<IEnumerable<ColorDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    Task<(IEnumerable<ColorDto> colors, string ids)> CreateColorCollectionAsync(IEnumerable<ColorForManipulationDto> colorCollection);
    Task DeleteColorAsync(int colorId, bool trackChanges);
    Task UpdateColorAsync(int colorId, ColorForManipulationDto colorForUpdate, bool trackChanges);
}
