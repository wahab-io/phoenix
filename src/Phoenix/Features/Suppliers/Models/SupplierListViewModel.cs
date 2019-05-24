using System;
using System.Collections.Generic;
using AutoMapper;

namespace Phoenix.Features.Suppliers
{
    public sealed class SupplierListViewModel
    {
        public IEnumerable<SupplierViewModel> Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public bool HasPrevious 
        {
            get
            {
                return Page > 1;
            }
        }
        public bool HasNext 
        { 
            get 
            {
                return Page < (int)Math.Ceiling((double)Total / Size);
            }
        }
        public int Total { get; set; }
    }
}