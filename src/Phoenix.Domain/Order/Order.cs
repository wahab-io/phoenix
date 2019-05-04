using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public sealed class Order : IEntity
    {
        public Order(Supplier supplier, Customer customer)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            
            Supplier = supplier;
            Customer = customer;
            LineItems = new HashSet<LineItem>();
            CreatedOn = DateTime.UtcNow;

        }
        public long Id => throw new NotImplementedException();
        public Supplier Supplier { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<LineItem> LineItems { get; private set; }
        public OrderState State { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public float Total 
        { 
            get
            {
                float sum = 0.0F;
                if (LineItems.Count > 0)
                {
                    foreach(var item in LineItems)
                    {
                        sum += item.Product.Price.Amount * item.Quantity;
                    }
                }
                return sum;
            }
        }

        public void AddLineItem(Product product, int quantity, int discount)
        {
            LineItems.Add(new LineItem(product, quantity, discount));
        }

        public void RemoveLineItem(LineItem lineItem)
        {
            LineItems.Remove(lineItem);
        }
    }
}