using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Customers
{
    public interface ICustomerService
    {
        int TotalCustomers { get; }
        IEnumerable<Customer> GetAllCustomers(int page, int size);
        Customer GetCustomerById(long id);
        Customer CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(long id);
    }
}