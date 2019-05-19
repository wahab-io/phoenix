using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Domain.Suppliers;

namespace Phoenix.Infrastructure.Services
{
    public sealed class SupplierService : ISupplierService
    {
        private readonly PhoenixContext _context = null;
        public SupplierService(PhoenixContext context)
        {
            _context = context;            
        }

        public int TotalSuppliers 
        {
            get
            {
                return _context.Suppliers
                    .Where(c => !c.IsArchived)
                    .Count();
            }
        }

        public IEnumerable<Supplier> GetAllSuppliers(int page, int size)
        {
            if (page == default(int))
                throw new ArgumentOutOfRangeException(nameof(page));
            
            if (size == default(int) && size < 1 || size > 25)
                throw new ArgumentOutOfRangeException(nameof(size));           

            return _context.Suppliers
                .Where(c => !c.IsArchived)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Supplier GetSupplierById(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));
            
            return _context.Suppliers
                .Where(c => !c.IsArchived)
                .FirstOrDefault(c => c.Id == id);
        }

        public Supplier CreateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            
            if (supplier.Id != default(long))
                throw new ArgumentOutOfRangeException(nameof(supplier.Id));
            
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return supplier;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            if (supplier.Id == default(long))
                throw new ArgumentOutOfRangeException(nameof(supplier.Id));
            
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(long id)
        {
            if (id == default(long))
                throw new ArgumentOutOfRangeException(nameof(id));

            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
                throw new KeyNotFoundException();
            
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}