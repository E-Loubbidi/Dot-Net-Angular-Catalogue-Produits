using CatalogueApp.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CatalogueApp
{
    public class CatalogueRepository:DbContext
    {
        public DbSet<Category> Categories {get; set;} 
        public DbSet<Product> Products {get; set;} 
        public DbSet<Customer> Customers {get; set;} 
        
        public CatalogueRepository(DbContextOptions options):base(options){

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property(e => e.Characteristics)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}