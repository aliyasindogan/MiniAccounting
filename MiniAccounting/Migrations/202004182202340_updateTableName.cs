namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Manufacturers", newName: "Manufacturer");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Manufacturer", newName: "Manufacturers");
        }
    }
}
