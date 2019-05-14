using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Phoenix.Domain;

namespace Phoenix.Infrastructure.EFCore
{
    public sealed class PhoenixContext : DbContext
    {
        public PhoenixContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer[]
                {
                    new Customer { Id = 1, Name = "Apple Inc.", StreetLine1 = "1 Infinite Loop", City = "Cupertino", State = "CA", ZipCode = "98712" },
                    new Customer { Id = 2, Name = "Google Inc.", StreetLine1 = "20 Main St.", City = "Mountain View", State = "CA", ZipCode = "96147" },
                    new Customer { Id = 3, Name = "Facbook Inc.", StreetLine1 = "100 Social Dr.", City = "Palo Alto", State = "CA", ZipCode = "92618" }
                }
            );
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }       
    }
}