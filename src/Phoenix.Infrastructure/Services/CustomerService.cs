using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Domain.Customers;

namespace Phoenix.Infrastructure.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly PhoenixContext _context = null;
        public CustomerService(PhoenixContext context)
        {
            _context = context;            
        }

        public int TotalCustomers 
        {
            get
            {
                return _context.Customers
                    .Where(c => !c.IsArchived)
                    .Count();
            }
        }

        public IEnumerable<Customer> GetAllCustomers(int page, int size)
        {
            if (page == default(int))
                throw new ArgumentOutOfRangeException(nameof(page));
            
            if (size == default(int) && size < 1 || size > 25)
                throw new ArgumentOutOfRangeException(nameof(size));           

            return _context.Customers
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Customer GetCustomerById(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));
            
            return _context.Customers
                .FirstOrDefault(c => c.Id == id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            
            if (customer.Id != default(long))
                throw new ArgumentOutOfRangeException(nameof(customer.Id));
            
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (customer.Id == default(long))
                throw new ArgumentOutOfRangeException(nameof(customer.Id));
            
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));

            var customer = _context.Customers.Find(id);
            if (customer == null)
                throw new KeyNotFoundException();
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}