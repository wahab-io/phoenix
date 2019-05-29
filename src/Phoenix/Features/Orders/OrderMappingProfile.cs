using System;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Orders
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<GetOrderResponse, OrderViewModel>();
            CreateMap<GetAllOrdersResponse, OrderListViewModel>();
        }
    }
}