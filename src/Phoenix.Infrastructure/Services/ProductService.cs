using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Domain.Products;

namespace Phoenix.Infrastructure.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly PhoenixContext _context = null;
        public ProductService(PhoenixContext context)
        {
            _context = context;            
        }

        public int TotalProducts
        {
            get
            {
                return _context.Products
                    .Where(c => !c.IsArchived)
                    .Count();
            }
        }

        public IEnumerable<Product> GetAllProducts(int page, int size)
        {
            if (page == default(int))
                throw new ArgumentOutOfRangeException(nameof(page));
            
            if (size == default(int) && size < 1 || size > 25)
                throw new ArgumentOutOfRangeException(nameof(size));           

            return _context.Products
                .Where(c => !c.IsArchived)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Product GetProductById(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));
            
            return _context.Products
                .Where(c => !c.IsArchived)
                .FirstOrDefault(c => c.Id == id);
        }

        public Product CreateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            if (product.Id != default(long))
                throw new ArgumentOutOfRangeException(nameof(product.Id));
            
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.Id == default(long))
                throw new ArgumentOutOfRangeException(nameof(product.Id));
            
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));

            var product = _context.Products.Find(id);
            if (product == null)
                throw new KeyNotFoundException();
            
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}