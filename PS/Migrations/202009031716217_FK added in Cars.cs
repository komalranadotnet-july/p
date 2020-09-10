namespace PS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKaddedinCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "customer_Id", c => c.Int());
            CreateIndex("dbo.Cars", "customer_Id");
            AddForeignKey("dbo.Cars", "customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "customer_Id" });
            DropColumn("dbo.Cars", "customer_Id");
            DropColumn("dbo.Cars", "CId");
        }
    }
}
