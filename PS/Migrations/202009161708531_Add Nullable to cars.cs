namespace PS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullabletocars : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Miles", c => c.Single());
            AlterColumn("dbo.Services", "TotPrice", c => c.Single());
            AlterColumn("dbo.Services", "CarsId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "CarsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Services", "TotPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Services", "Miles", c => c.Single(nullable: false));
        }
    }
}
