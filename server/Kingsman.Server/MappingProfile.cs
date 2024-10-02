namespace Kingsman.Server;

using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Brand Mapping
        CreateMap<Brand, BrandDto>();
        CreateMap<BrandForManipulationDto, Brand>();

        // Category Mapping
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForManipulationDto, Category>();

        // Color Mapping
        CreateMap<Color, ColorDto>();
        CreateMap<ColorForManipulationDto, Color>();

        // Customer Mapping
        CreateMap<User, UserDto>();

        // Order Mapping
        CreateMap<Order, OrderDto>();
        CreateMap<OrderForManipulationDto, Order>();

        // OrderItem Mapping
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<OrderItemForManipulationDto, OrderItem>();

        // Product Mapping
        CreateMap<Product, ProductDto>();
        CreateMap<ProductForManipulationDto, Product>();

        CreateMap<UserForRegistrationDto, User>();
    }
}
