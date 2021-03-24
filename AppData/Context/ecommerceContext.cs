using eCommerceWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.AppData.Context
{
    public class ecommerceContext : DbContext
    {
        public ecommerceContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    new DBcategory(modelBuilder.Entity<Category>());
        //}
        public DbSet<DBcategory> DBCategory { get; set; }
        public DbSet<DBrole> DBRole { get; set; }
        public DbSet<DBusers> DBusers { get; set; }
        public DbSet<DBproduct> DBProduct { get; set; }
        public DbSet<DBproductximage> DBProductxImages { get; set; }
        public DbSet<DBspecificationtype> DBSpecificationtypes { get; set; }
        public DbSet<DBfeaturetype> DBFeaturetypes { get; set; }
        public DbSet<DBspecificationsXcategory> DBSpecificationsXCategories { get; set; }
        public DbSet<DBspecification> DBSpecifications { get; set; }
    }
}
