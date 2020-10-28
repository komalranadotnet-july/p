namespace PS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validationremoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
    }
}
