using System;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Suppliers
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<GetSupplierResponse, SupplierViewModel>();
            CreateMap<GetAllSuppliersResponse, SupplierListViewModel>();
        }
    }
}