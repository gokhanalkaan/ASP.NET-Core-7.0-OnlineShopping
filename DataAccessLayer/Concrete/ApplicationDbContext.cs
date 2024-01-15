using EntityLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        builder.Entity<AppUser>()
       .HasOne(a => a.Cart)
       .WithOne(b => b.User)
       .HasForeignKey<Cart>(b => b.UserId);









            builder.Entity<Category>().HasData(
                new Category { Id=1,CategoryName="Phone"},
                new Category { Id =2, CategoryName = "Laptop" }

                );
            builder.Entity<ProductCategory>().HasData(
               new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
              new ProductCategory { Id = 2, ProductId = 2, CategoryId = 2 },
               new ProductCategory { Id = 3, ProductId = 3, CategoryId = 1 }

              );
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    ProductName="IPhone 15",
                   
                    ProductDescription="IPhone 15 Description",
                    ProductPrice=1250,
                    ProductTitle="IPhone 12 Title"

                },
                 new Product
                 {
                     Id=2,
                     ProductName = "Asus Laptop 10",
                    
                     ProductDescription = "Asus Laptop 10 Description",
                     ProductPrice = 1450,
                     ProductTitle = "Asus Laptop 10 Title"

                 },
                  new Product
                  {
                      Id = 3,
                      ProductName = "Samsung Galaxy S20",
                     
                      ProductDescription = "Samsung Galaxy S20 Description",
                      ProductPrice = 954,
                      ProductTitle = "Samsung Galaxy S20 Title"

                  }


                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            
            optionsBuilder.UseSqlServer("Data Source=Gökhan\\MSSQLSERVER01;Initial Catalog=MvcCoreOnlineShoppingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Cart>  Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Comment> Comments { get; set; }

     


    }
    
}
