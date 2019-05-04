using System;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public sealed class LineItem : IEntity
    {
        public LineItem(Product product, int quantity, int discount = 0)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            Product = product;

            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            Quantity = quantity;

            if (discount <= 0)
                throw new ArgumentOutOfRangeException(nameof(discount));
            Discount = discount;
        }

        public long Id { get; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public int Discount { get; private set; }
    }
}