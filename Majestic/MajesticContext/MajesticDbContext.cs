using Majestic.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.MajesticContext
{
    public class MajesticDbContext : DbContext
    {
        public MajesticDbContext()
        {
        }

        public MajesticDbContext(DbContextOptions<MajesticDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                /* .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);*/
                IConfigurationRoot config = builder.Build();
                var connectionString = "Server=XIPL9374\\SQLEXPRESS; Database=Majestic;Integrated Security=True; Trusted_Connection = True; MultipleActiveResultSets=true ";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Product> Products { get; set; }
      
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Details> Details { get; set; }


    }
}
