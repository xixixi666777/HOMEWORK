using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using static _3_20_C_.OrderManager;

namespace OrderManagerEF
{
    public class OrderContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=orderdb;user=root;password=050917;",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.OrderId, od.GoodsId });

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne(d => d.Order)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(d => d.Item)
                .WithMany()
                .HasForeignKey(d => d.GoodsId);
        }
    }
}

