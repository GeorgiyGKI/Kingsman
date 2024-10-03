using Swashbuckle.AspNetCore.Annotations;

namespace Shared.RequestFeatures;

public class ProductParameters : RequestParameters
{
    public string OrderBy { get; set; } = "name";
    public uint MinPrice { get; set; }
    public uint MaxPrice { get; set; } = int.MaxValue;
    [SwaggerSchema(ReadOnly = true)]
    public bool ValidPriceRange => MaxPrice > MinPrice;

    public string? SearchTerm { get; set; }
}   