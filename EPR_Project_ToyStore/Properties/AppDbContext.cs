using System;
using System.Data.SqlClient;
using EPR_Project_ToyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EPR_Project_ToyStore.Properties
{
    public class AppDbContext : DbContext
    {

        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "ToyShopDB",
            UserID = "taw",
            Password = "NewStrongPassword123",
            TrustServerCertificate = true
        };

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            }
        }


        public DbSet<ItemModel> Items { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CartModel> Cart { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<CheckoutModel> Checkout { get; set; }
        public DbSet<CartItemModel> CartItem { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderModel>()
        //        .HasOne(o => o.Item)
        //        .WithMany() // Assuming one-to-many relationship
        //        .HasForeignKey(o => o.ItemId);
        //}
    }
}
