using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Orders
{
    public interface IOrderService
    {
        int TotalOrders { get; }
        IEnumerable<Order> GetAllOrders(int page, int size);
        Order GetOrderById(long id);
        Order CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(long id);
    }
}