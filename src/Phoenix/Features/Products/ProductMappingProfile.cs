using System;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<GetProductResponse, ProductViewModel>();
            CreateMap<GetAllProductsResponse, ProductListViewModel>();
        }
    }
}