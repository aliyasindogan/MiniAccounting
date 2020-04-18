namespace MiniAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class databaseUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CardCustomer", newName: "Customer");
            RenameTable(name: "dbo.CardStock", newName: "Stock");
            AddColumn("dbo.Category", "CreatedUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Category", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Category", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.Category", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Category", "IsDisplay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Category", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.UserRole", "CreatedUserID", c => c.Int(nullable: false));
            AddColumn("dbo.UserRole", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserRole", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.UserRole", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserRole", "IsDisplay", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserRole", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.User", "CreatedUserID", c => c.Int());
            AddColumn("dbo.User", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.User", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.User", "IsDisplay", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CreatedUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customer", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.Customer", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Customer", "IsDisplay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Stock", "CreatedUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Stock", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stock", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.Stock", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Stock", "IsDisplay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stock", "DisplayOrder", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Stock", "DisplayOrder");
            DropColumn("dbo.Stock", "IsDisplay");
            DropColumn("dbo.Stock", "ModifiedDate");
            DropColumn("dbo.Stock", "ModifiedUserID");
            DropColumn("dbo.Stock", "CreatedDate");
            DropColumn("dbo.Stock", "CreatedUserID");
            DropColumn("dbo.Customer", "DisplayOrder");
            DropColumn("dbo.Customer", "IsDisplay");
            DropColumn("dbo.Customer", "ModifiedDate");
            DropColumn("dbo.Customer", "ModifiedUserID");
            DropColumn("dbo.Customer", "CreatedDate");
            DropColumn("dbo.Customer", "CreatedUserID");
            DropColumn("dbo.User", "DisplayOrder");
            DropColumn("dbo.User", "IsDisplay");
            DropColumn("dbo.User", "ModifiedDate");
            DropColumn("dbo.User", "ModifiedUserID");
            DropColumn("dbo.User", "CreatedDate");
            DropColumn("dbo.User", "CreatedUserID");
            DropColumn("dbo.UserRole", "DisplayOrder");
            DropColumn("dbo.UserRole", "IsDisplay");
            DropColumn("dbo.UserRole", "ModifiedDate");
            DropColumn("dbo.UserRole", "ModifiedUserID");
            DropColumn("dbo.UserRole", "CreatedDate");
            DropColumn("dbo.UserRole", "CreatedUserID");
            DropColumn("dbo.Category", "DisplayOrder");
            DropColumn("dbo.Category", "IsDisplay");
            DropColumn("dbo.Category", "ModifiedDate");
            DropColumn("dbo.Category", "ModifiedUserID");
            DropColumn("dbo.Category", "CreatedDate");
            DropColumn("dbo.Category", "CreatedUserID");
            RenameTable(name: "dbo.Stock", newName: "CardStock");
            RenameTable(name: "dbo.Customer", newName: "CardCustomer");
        }
    }
}