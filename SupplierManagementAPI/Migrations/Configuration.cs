namespace SupplierManagementAPI.Migrations
{
    using SupplierManagementAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SupplierManagementAPI.DAL.SupplierManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SupplierManagementAPI.DAL.SupplierManagementDbContext";
        }

        protected override void Seed(SupplierManagementAPI.DAL.SupplierManagementDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //Kathgories promh8eutwn na uparxoun sthn bash
            var supplierCategories = new List<SupplierCategory>
            {
                /*
                 * Food supplier,
                 * Room Equipment,
                 * Electronic equipment 
                 */
                new SupplierCategory
                {
                    ID=1,
                    CategoryName="Food Supplier"
                },
                new SupplierCategory
                {
                    ID=2,
                    CategoryName="Room Equipment"
                },
                new SupplierCategory
                {
                    ID=3,
                    CategoryName="Electronic Equipment"
                }
            };
            supplierCategories.ForEach(s => context.SupplierCategories.AddOrUpdate(s));
            context.SaveChanges();

            //Kathgories Xwrwn na uparxoun sthn bash
            var supplierCountries = new List<SupplierCountry>
            {
                new SupplierCountry
                {
                    ID=1,
                    CountryName="Greece"
                },
                new SupplierCountry
                {
                    ID=2,
                    CountryName="France"
                },
                new SupplierCountry
                {
                    ID=3,
                    CountryName="Italy"
                },
                new SupplierCountry
                {
                    ID=4,
                    CountryName="Spain"
                },
            };
            supplierCountries.ForEach(s => context.SupplierCountries.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
