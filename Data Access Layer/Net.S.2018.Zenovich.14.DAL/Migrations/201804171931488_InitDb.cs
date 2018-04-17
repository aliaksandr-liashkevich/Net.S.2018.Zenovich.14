namespace Net.S._2018.Zenovich._14.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        Ownder_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Ownder_id, cascadeDelete: true)
                .Index(t => t.Ownder_id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Ownder_id", "dbo.People");
            DropIndex("dbo.Accounts", new[] { "Ownder_id" });
            DropTable("dbo.People");
            DropTable("dbo.Accounts");
        }
    }
}
