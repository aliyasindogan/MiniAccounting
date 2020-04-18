namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturer", "AuthorizedFirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Manufacturer", "AuthorizedLastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Manufacturer", "Phone", c => c.String(maxLength: 50));
            AddColumn("dbo.Manufacturer", "Description", c => c.String());
            AddColumn("dbo.Manufacturer", "CityID", c => c.Int());
            AddColumn("dbo.Manufacturer", "Address", c => c.String());
            CreateIndex("dbo.Manufacturer", "CityID");
            AddForeignKey("dbo.Manufacturer", "CityID", "dbo.City", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manufacturer", "CityID", "dbo.City");
            DropIndex("dbo.Manufacturer", new[] { "CityID" });
            DropColumn("dbo.Manufacturer", "Address");
            DropColumn("dbo.Manufacturer", "CityID");
            DropColumn("dbo.Manufacturer", "Description");
            DropColumn("dbo.Manufacturer", "Phone");
            DropColumn("dbo.Manufacturer", "AuthorizedLastName");
            DropColumn("dbo.Manufacturer", "AuthorizedFirstName");
        }
    }
}
