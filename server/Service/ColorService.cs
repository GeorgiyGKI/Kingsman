using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service;

internal sealed class ColorService : IColorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ColorService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ColorDto>> GetAllColorsAsync(bool trackChanges)
    {
        var colors = await _repository.Color.GetAllColorsAsync(trackChanges);

        var colorsDto = _mapper.Map<IEnumerable<ColorDto>>(colors);

        return colorsDto;
    }

    public async Task<ColorDto> GetColorAsync(int id, bool trackChanges)
    {
        var color = await GetColorAndCheckIfItExists(id, trackChanges);

        var colorDto = _mapper.Map<ColorDto>(color);

        return colorDto;
    }

    public async Task<ColorDto> CreateColorAsync(ColorForManipulationDto color)
    {
        var colorEntity = _mapper.Map<Color>(color);

        _repository.Color.CreateColor(colorEntity);
        await _repository.SaveAsync();

        var colorToReturn = _mapper.Map<ColorDto>(colorEntity);

        return colorToReturn;
    }

    public async Task<IEnumerable<ColorDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        ArgumentNullException.ThrowIfNull(ids);

        var colorEntities = await _repository.Color.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != colorEntities.Count())
            throw new ArgumentOutOfRangeException();

        var colorsToReturn = _mapper.Map<IEnumerable<ColorDto>>(colorEntities);

        return colorsToReturn;
    }

    public async Task<(IEnumerable<ColorDto> colors, string ids)> CreateColorCollectionAsync
        (IEnumerable<ColorForManipulationDto> colorCollection)
    {
        ArgumentNullException.ThrowIfNull(colorCollection);

        var colorEntities = _mapper.Map<IEnumerable<Color>>(colorCollection);
        foreach (var color in colorEntities)
        {
            _repository.Color.CreateColor(color);
        }

        await _repository.SaveAsync();

        var colorCollectionToReturn = _mapper.Map<IEnumerable<ColorDto>>(colorEntities);
        var ids = string.Join(",", colorCollectionToReturn.Select(c => c.Id));

        return (colors: colorCollectionToReturn, ids);
    }

    public async Task DeleteColorAsync(int colorId, bool trackChanges)
    {
        var color = await GetColorAndCheckIfItExists(colorId, trackChanges);

        _repository.Color.DeleteColor(color);
        await _repository.SaveAsync();
    }

    public async Task UpdateColorAsync(
        int colorId,
        ColorForManipulationDto colorForUpdate,
        bool trackChanges)
    {
        var color = await GetColorAndCheckIfItExists(colorId, trackChanges);

        _mapper.Map(colorForUpdate, color);
        await _repository.SaveAsync();
    }

    private async Task<Color> GetColorAndCheckIfItExists(int id, bool trackChanges)
    {
        var color = await _repository.Color.GetColorAsync(id, trackChanges);
        ArgumentNullException.ThrowIfNull(color);

        return color;
    }
}
