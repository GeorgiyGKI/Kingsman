using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasData
       (
           new OrderItem
           {
               Id = new Guid("dddd1111-1111-1111-1111-111111111111"),
               Quantity = 2,
               UnitPrice = 50.00m,
               OrderId = new Guid("aaaa1111-1111-1111-1111-111111111111"), // Связь с Order
               ProductId = new Guid("11111111-1111-1111-1111-111111111111")  // Связь с Product
           },
           new OrderItem
           {
               Id = new Guid("dddd2111-1111-1111-1111-111111111111"),
               Quantity = 2,
               UnitPrice = 50.00m,
               OrderId = new Guid("bbbb2222-2222-2222-2222-222222222222"), // Связь с Order
               ProductId = new Guid("11111111-1111-1111-1111-111111111111")  // Связь с Product
           },
           new OrderItem
           {
               Id = new Guid("eeee2222-2222-2222-2222-222222222222"),
               Quantity = 1,
               UnitPrice = 200.00m,
               OrderId = new Guid("bbbb2222-2222-2222-2222-222222222222"), // Связь с Order
               ProductId = new Guid("22222222-2222-2222-2222-222222222222")  // Связь с Product
           },
           new OrderItem
           {
               Id = new Guid("ffff3333-3333-3333-3333-333333333333"),
               Quantity = 3,
               UnitPrice = 100.00m,
               OrderId = new Guid("bbbb2222-2222-2222-2222-222222222222"), // Связь с Order
               ProductId = new Guid("33333333-3333-3333-3333-333333333333")  // Связь с Product
           }
       );
    }
}