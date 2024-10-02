using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasData
        (
             new Color
             {
                 Id = 1,
                 Name = "Red",
                 HexValue = "#FF0000",
                 RgbValue = "255,0,0"
             },
            new Color
            {
                Id = 2,
                Name = "Green",
                HexValue = "#00FF00",
                RgbValue = "0,255,0"
            },
            new Color
            {
                Id = 3,
                Name = "Blue",
                HexValue = "#0000FF",
                RgbValue = "0,0,255"
            }
        );
    }
}