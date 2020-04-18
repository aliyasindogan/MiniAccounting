namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cities", newName: "City");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.City", newName: "Cities");
        }
    }
}
