using SupplierManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupplierManagementAPI.DAL
{
    public class SupplierManagementDbContext : DbContext
    {
        public SupplierManagementDbContext() : base("SupplierManagementDbNew") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierCategory> SupplierCategories { get; set; }
        public DbSet<SupplierCountry> SupplierCountries { get; set; }
        // an uphrxan CRUD operation me SupplierCustomer kai SupplierCategory na mhn esbhne tous Supplier
        // mesw Fulent Api na mhn kanei Cascade Delete
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}