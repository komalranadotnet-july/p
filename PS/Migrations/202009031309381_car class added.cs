namespace PS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carclassadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarsId = c.Int(nullable: false, identity: true),
                        Vin = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Style = c.String(),
                        MYear = c.Int(nullable: false),
                        Color = c.String(),
                        Uid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
