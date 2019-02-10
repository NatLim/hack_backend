using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.dbhelper
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public class Community
    {
        [Key]
        public int Id { get; set; }
        public int productId { get; set; }
        public string Status { get; set; }
        public string Method { get; set; }

        public virtual Product Product { get; set; }
    }

    public class FridgeProduct
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }

    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ExpireDays { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Community> Communities { get; set; }
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }

    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<FridgeProduct> fridgeProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>()
                .HasKey(c => new { c.Id});

            modelBuilder.Entity<FridgeProduct>()
                .HasKey(FP => new { FP.Id });

            modelBuilder.Entity<Product>()
                .HasKey(P => new { P.Id });

            modelBuilder.Entity<Community>()
                .HasOne(c=> c.Product)
                .WithMany(c=> c.Communities)
                .HasForeignKey(fk=> new { fk.productId})
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<FridgeProduct>()
                .HasOne(FP=> FP.Product)
                .WithMany(FP=> FP.FridgeProducts)
                .HasForeignKey(fk=> new { fk.ProductId })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Product>()
                .HasOne(P=> P.Category)
                .WithMany(P=> P.Products)
                .HasForeignKey(fk=> new { fk.CategoryId})
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        }


    }
}
