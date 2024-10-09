using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData
        (
             new Product
             {
                 Id = new Guid("11111111-1111-1111-1111-111111111111"),
                 Name = "Red T-Shirt",
                 Description = "A red t-shirt made of 100% cotton.",
                 Price = 19.99m,
                 Stock = 100,
                 Size = Size.M,
                 RefNumber = "RTS1001",
                 CategoryId = 2, // Overshirts
                 BrandId = 3, // Nike
                 ColorId = 1  // Red
             },
            new Product
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "Blue Sneakers",
                Description = "Comfortable blue sneakers for everyday wear.",
                Price = 49.99m,
                Stock = 50,
                Size = Size.L,
                RefNumber = "BSK2002",
                CategoryId = 3, // Bombers
                BrandId = 2, // Adidas
                ColorId = 3  // Blue
            },
            new Product
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "Green Jacket",
                Description = "A stylish green jacket with a hood.",
                Price = 79.99m,
                Stock = 30,
                Size = Size.XL,
                RefNumber = "GJ3003",
                CategoryId = 1, // Jackets
                BrandId = 1, // Puma
                ColorId = 2  // Green
            }
        );
    }
}