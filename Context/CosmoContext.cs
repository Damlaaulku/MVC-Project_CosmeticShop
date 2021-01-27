using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CosmeticShop.Entities;

namespace CosmeticShop.Context
{
    public class CosmoContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //IDler
            modelBuilder.Entity<Products>().HasKey(x => x.Id);
            modelBuilder.Entity<Users>().HasKey(x => x.Id);
            modelBuilder.Entity<Wishlist>().HasRequired(x => x.User).WithMany(y => y.Wishlist).HasForeignKey(x => x.UserID);
            modelBuilder.Entity<Categories>().HasMany(x => x.Products)
                .WithMany(y => y.Categories)
                .Map(ma => {
                    ma.MapLeftKey("CategoryID");
                    ma.MapRightKey("ProductID");
                    ma.ToTable("ProductCategories");
                }); 


        }
        public CosmoContext() : base("CosmoContext")
        {

        }
    }
}