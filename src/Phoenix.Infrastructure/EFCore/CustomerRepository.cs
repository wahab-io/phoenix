using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Phoenix.Core;
using Phoenix.Domain;

namespace Phoenix.Infrastructure.EFCore
{
    public sealed class CustomerService : DbContext, ICustomerService
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        public CustomerService(ILogger logger, IOrderService orderService)
        {
            _logger = logger;
            _logger.LogDebug("Creating CustomerService");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }

        public void CreateOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void FindCustomer(long id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool SearchCustomer(string query)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}