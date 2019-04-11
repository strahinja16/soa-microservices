using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics",
            },
            new Category
            {
                Id = 2,
                Name = "Clothes",
            },
            new Category
            {
                Id = 3,
                Name = "Grocery",
            }
            );
        }
    }
}
