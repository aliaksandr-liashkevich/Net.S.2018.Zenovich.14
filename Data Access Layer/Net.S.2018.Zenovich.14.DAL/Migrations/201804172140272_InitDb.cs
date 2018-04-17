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
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        Owner_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Owner_Id", "dbo.People");
            DropIndex("dbo.Accounts", new[] { "Owner_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Accounts");
        }
    }
}
