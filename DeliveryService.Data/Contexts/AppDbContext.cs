using DeliveryService.Domain.Entities.Categories;
using DeliveryService.Domain.Entities.Compositions;
using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Domain.Entities.Orders;
using DeliveryService.Domain.Entities.Products;
using DeliveryService.Domain.Entities.TimeCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<TimeCategory> TimeCategories { get; set; }
    }
}
