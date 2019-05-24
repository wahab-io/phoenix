using System;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Customers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<GetCustomerResponse, CustomerViewModel>();
            CreateMap<GetAllCustomersResponse, CustomerListViewModel>();            
        }
    }
}