using AutoMapper;
using DeliveryService.Domain.Entities.Categories;
using DeliveryService.Domain.Entities.Compositions;
using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Domain.Entities.Orders;
using DeliveryService.Domain.Entities.Products;
using DeliveryService.Domain.Entities.TimeCategories;
using DeliveryService.Service.DTOs.Categories;
using DeliveryService.Service.DTOs.Compositions;
using DeliveryService.Service.DTOs.Customers;
using DeliveryService.Service.DTOs.OrderDetailsDto;
using DeliveryService.Service.DTOs.Ordrers;
using DeliveryService.Service.DTOs.Products;
using DeliveryService.Service.DTOs.TimeCategories;

namespace DeliveryService.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForCreationDto>().ReverseMap();
            CreateMap<Category, CategoryForCreationDto>().ReverseMap();
            CreateMap<Composition, CompositionForCreationDto>().ReverseMap();
            CreateMap<Order, OrderForCreationDto>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsForCreationDto>().ReverseMap();
            CreateMap<Product, ProductForCreationDto>().ReverseMap();
            CreateMap<TimeCategory, TimeCategoryForCreationDto>().ReverseMap();
        }
    }
}
