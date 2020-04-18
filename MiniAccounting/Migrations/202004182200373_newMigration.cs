namespace MiniAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatedUserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUserID = c.Int(),
                        ModifiedDate = c.DateTime(),
                        IsDisplay = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.sysdiagrams");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Manufacturers");
        }
    }
}
