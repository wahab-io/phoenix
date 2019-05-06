using System;

namespace Phoenix.Domain
{
    public interface ICustomerService
    {
        void FindCustomer(long id);
        void AddCustomer(Customer newCustomer);
        void UpdateCustomer(Customer customer);
        bool RemoveCustomer(Customer customer);
        bool SearchCustomer(string query);
        void CreateOrder(Order newOrder);
    }
}