namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardCustomer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Description = c.String(),
                        CityID = c.Int(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CardStock",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockCode = c.String(nullable: false, maxLength: 50),
                        StockName = c.String(nullable: false, maxLength: 500),
                        TaxRateID = c.Int(nullable: false),
                        MeasurementUnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasurementUnit", t => t.MeasurementUnitID, cascadeDelete: true)
                .ForeignKey("dbo.TaxRate", t => t.TaxRateID, cascadeDelete: true)
                .Index(t => t.TaxRateID)
                .Index(t => t.MeasurementUnitID);
            
            CreateTable(
                "dbo.MeasurementUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurementUnitName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxRate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxName = c.String(nullable: false, maxLength: 50),
                        TaxRateValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        SubCategoryID = c.Int(nullable: false),
                        CategoryTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryType", t => t.CategoryTypeID, cascadeDelete: true)
                .Index(t => t.CategoryTypeID);
            
            CreateTable(
                "dbo.CategoryType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.UserType", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        UserTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserType", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.User", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.UserRole", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Category", "CategoryTypeID", "dbo.CategoryType");
            DropForeignKey("dbo.CardStock", "TaxRateID", "dbo.TaxRate");
            DropForeignKey("dbo.CardStock", "MeasurementUnitID", "dbo.MeasurementUnit");
            DropForeignKey("dbo.CardCustomer", "CityID", "dbo.Cities");
            DropIndex("dbo.User", new[] { "UserTypeID" });
            DropIndex("dbo.UserRole", new[] { "CategoryID" });
            DropIndex("dbo.UserRole", new[] { "UserTypeID" });
            DropIndex("dbo.Category", new[] { "CategoryTypeID" });
            DropIndex("dbo.CardStock", new[] { "MeasurementUnitID" });
            DropIndex("dbo.CardStock", new[] { "TaxRateID" });
            DropIndex("dbo.CardCustomer", new[] { "CityID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.User");
            DropTable("dbo.UserType");
            DropTable("dbo.UserRole");
            DropTable("dbo.CategoryType");
            DropTable("dbo.Category");
            DropTable("dbo.TaxRate");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.CardStock");
            DropTable("dbo.Cities");
            DropTable("dbo.CardCustomer");
        }
    }
}
