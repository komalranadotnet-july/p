namespace PS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSevicesandServiceTypestableindatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miles = c.Single(nullable: false),
                        TotPrice = c.Single(nullable: false),
                        Details = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CarsId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        ServiceTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypes_Id)
                .Index(t => t.ServiceTypes_Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceTypes_Id", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "ServiceTypes_Id" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
        }
    }
}
