using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(new Product{
                Id = -1,
                Name = "Name",
                Price = 39.90M,
                Description = "Description",
                ImageUrl = "Image",
                CategoryName = "Category"
            });

            modelBuilder.Entity<Product>().HasData(new Product{
                Id = -2,
                Name = "Name2",
                Price = 49.90M,
                Description = "Description2",
                ImageUrl = "Image2",
                CategoryName = "Category2"
            });
        }
    }

}