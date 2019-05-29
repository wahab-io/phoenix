using System;
using AutoMapper;
using Phoenix.Domain.Customers;
using Phoenix.Domain.Suppliers;
using Phoenix.Domain.Products;
using Phoenix.Domain.Orders;

namespace Phoenix.Services
{
    public class PhoenixMappingProfile : Profile
    {
        public PhoenixMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, NewCustomerDto>().ReverseMap();
            
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, NewSupplierDto>().ReverseMap();

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, NewProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderDto>().ReverseMap();   
            CreateMap<Order, NewOrderDto>().ReverseMap();
        }
    }
}