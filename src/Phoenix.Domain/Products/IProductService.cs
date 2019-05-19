using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Products
{
    public interface IProductService
    {
        int TotalProducts { get; }
        IEnumerable<Product> GetAllProducts(int page, int size);
        Product GetProductById(long id);
        Product CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long id);
    }
}