using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions opsions) : base(opsions)  
        {

        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

      protected   override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Bevarage", Description = "Bevarage" },
         new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
         new Category { CategoryId = 3, Name = "Meat", Description = "Meat" });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Продукт1", Quantity = 100, Price = 100 },

          new Product { ProductId = 2, CategoryId = 1, Name = "Продукт2", Quantity = 100, Price = 100 },
          new Product { ProductId = 3, CategoryId = 2, Name = "Продукт3", Quantity = 100, Price = 100 },
          new Product { ProductId = 4, CategoryId = 3, Name = "Продукт4", Quantity = 100, Price = 100 });
        }
        

    }
}
