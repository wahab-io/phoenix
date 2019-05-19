using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Phoenix.Domain;
using Phoenix.Domain.Customers;
using Phoenix.Domain.Suppliers;
using Phoenix.Domain.Orders;
using Phoenix.Domain.Products;

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
            modelBuilder.Entity<Customer>(entity => 
            {
                entity.ToTable("Customers")
                    .HasData(Seed.Customers());
            });
            
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers")
                    .HasData(Seed.Suppliers());
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products")
                    .HasData(Seed.Products());
            });

            modelBuilder.Entity<Product.Price>(entity =>
            {
                entity.ToTable("Prices");
            });

            modelBuilder.Entity<Order.LineItem>(entity => 
            {
                entity.ToTable("LineItems");
            });
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}