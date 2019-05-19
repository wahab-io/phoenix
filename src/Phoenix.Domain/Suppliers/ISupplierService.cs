using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Suppliers
{
    public interface ISupplierService
    {
        int TotalSuppliers { get; }
        IEnumerable<Supplier> GetAllSuppliers(int page, int size);
        Supplier GetSupplierById(long id);
        Supplier CreateSupplier(Supplier customer);
        void UpdateSupplier(Supplier customer);
        void DeleteSupplier(long id);
    }
}