namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.MeasurementUnit", t => t.MeasurementUnitID)
                .ForeignKey("dbo.TaxRate", t => t.TaxRateID)
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
                        SubCategoryID = c.Int(),
                        CategoryTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryType", t => t.CategoryTypeID)
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
                .ForeignKey("dbo.UserType", t => t.UserTypeID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
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
                        Password = c.String(maxLength: 50),
                        UserTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserType", t => t.UserTypeID)
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
            DropForeignKey("dbo.UserRole", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.UserRole", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.User", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.Category", "CategoryTypeID", "dbo.CategoryType");
            DropForeignKey("dbo.CardStock", "TaxRateID", "dbo.TaxRate");
            DropForeignKey("dbo.CardStock", "MeasurementUnitID", "dbo.MeasurementUnit");
            DropIndex("dbo.User", new[] { "UserTypeID" });
            DropIndex("dbo.UserRole", new[] { "CategoryID" });
            DropIndex("dbo.UserRole", new[] { "UserTypeID" });
            DropIndex("dbo.Category", new[] { "CategoryTypeID" });
            DropIndex("dbo.CardStock", new[] { "MeasurementUnitID" });
            DropIndex("dbo.CardStock", new[] { "TaxRateID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.User");
            DropTable("dbo.UserType");
            DropTable("dbo.UserRole");
            DropTable("dbo.CategoryType");
            DropTable("dbo.Category");
            DropTable("dbo.TaxRate");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.CardStock");
        }
    }
}
