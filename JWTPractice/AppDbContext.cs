using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTPractice
{
    public class AppDbContext : DbContext
    {
        /*
         * DbContext options required by ef
         * options carry configuration information
         * More -> https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
         */
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :base(dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                FirstName = "root",
                LastName = "admin",
                UserName = "rootAdmin",
                CreatedDateTime = DateTime.Now,
                Email = "admin@root.com",
                Password = "Secret1$",
                UserInfoId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                AvailableQuantity = 20,
                Category = "Toys",
                Color = "Red",
                Name = "Avenger",
                ProductId = 1,
                UnitPrice = 22.40M,
            });
        }
    }
}
