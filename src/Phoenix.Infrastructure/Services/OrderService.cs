using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Domain.Orders;

namespace Phoenix.Infrastructure.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly PhoenixContext _context = null;
        public OrderService(PhoenixContext context)
        {
            _context = context;            
        }

        public int TotalOrders 
        {
            get
            {
                return _context.Orders
                    .Where(c => !c.IsArchived)
                    .Count();
            }
        }

        public IEnumerable<Order> GetAllOrders(int page, int size)
        {
            if (page == default(int))
                throw new ArgumentOutOfRangeException(nameof(page));
            
            if (size == default(int) && size < 1 || size > 25)
                throw new ArgumentOutOfRangeException(nameof(size));           

            return _context.Orders
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Order GetOrderById(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));
            
            return _context.Orders
                .FirstOrDefault(c => c.Id == id);
        }

        public Order CreateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            
            if (order.Id != default(long))
                throw new ArgumentOutOfRangeException(nameof(order.Id));
            
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (order.Id == default(long))
                throw new ArgumentOutOfRangeException(nameof(order.Id));
            
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));

            var order = _context.Orders.Find(id);
            if (order == null)
                throw new KeyNotFoundException();
            
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}