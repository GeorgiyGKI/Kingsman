using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData
        (
            new Brand 
            { 
                Id = 1,
                Description = "des1",
                Name = "Puma"
            },
            new Brand
            {
                Id = 2,
                Description = "des2",
                Name = "Adidas"
            },
            new Brand
            {
                Id = 3,
                Description = "des3",
                Name = "Nike"
            }
        );
    }
}