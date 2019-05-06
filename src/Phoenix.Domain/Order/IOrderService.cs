using System;

namespace Phoenix.Domain
{
    public interface IOrderService
    {
        void CreateCustomerOrder(Customer customer, Order newOrder);
    }
}