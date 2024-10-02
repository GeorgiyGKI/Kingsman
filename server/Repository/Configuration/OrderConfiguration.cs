using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData
        (
            new Order
            {
                Id = new Guid("aaaa1111-1111-1111-1111-111111111111"),
                OrderDate = new DateTime(2023, 1, 1),
                TotalAmount = 100.00m,
                UserId = "11111111-1111-1111-1111-111111111111"
            },
            new Order
            {
                Id = new Guid("bbbb2222-2222-2222-2222-222222222222"),
                OrderDate = new DateTime(2023, 2, 1),
                TotalAmount = 200.00m,
                UserId = "22222222-2222-2222-2222-222222222222"
            }
        );
    }
}