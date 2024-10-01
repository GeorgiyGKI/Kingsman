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
        CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<BrandForManipulationDto, Brand>();

        // Category Mapping
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<CategoryForManipulationDto, Category>();

        // Color Mapping
        CreateMap<Color, ColorDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<ColorForManipulationDto, Color>();

        // Customer Mapping
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        CreateMap<CustomerForManipulationDto, Customer>();

        // Order Mapping
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer));
        CreateMap<OrderForManipulationDto, Order>();

        // OrderItem Mapping
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
        CreateMap<OrderItemForManipulationDto, OrderItem>();

        // Product Mapping
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));
        CreateMap<ProductForManipulationDto, Product>();

        CreateMap<UserForRegistrationDto, Customer>();
    }
}
