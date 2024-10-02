using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData
        (
            new Category { Id = 1, Name = "Jackets" },
            new Category { Id = 2, Name = "Overshirts" },
            new Category { Id = 3, Name = "Bombers" }
        );
    }
}