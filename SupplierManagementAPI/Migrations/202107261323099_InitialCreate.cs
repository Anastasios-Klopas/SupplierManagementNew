namespace SupplierManagementAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupplierCountries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Afm = c.Int(nullable: false),
                        Address = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        ActiveSupplier = c.Boolean(nullable: false),
                        SupplierCategoryID = c.Int(nullable: false),
                        SupplierCountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SupplierCategories", t => t.SupplierCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.SupplierCountries", t => t.SupplierCountryID, cascadeDelete: true)
                .Index(t => t.SupplierCategoryID)
                .Index(t => t.SupplierCountryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "SupplierCountryID", "dbo.SupplierCountries");
            DropForeignKey("dbo.Suppliers", "SupplierCategoryID", "dbo.SupplierCategories");
            DropIndex("dbo.Suppliers", new[] { "SupplierCountryID" });
            DropIndex("dbo.Suppliers", new[] { "SupplierCategoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierCountries");
            DropTable("dbo.SupplierCategories");
        }
    }
}
