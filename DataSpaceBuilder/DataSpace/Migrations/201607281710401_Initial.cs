namespace DataSpace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Picture = c.String(),
                        Name = c.String(),
                        PlanetType = c.String(),
                        DistanceFromSun = c.String(),
                        Diameter = c.String(),
                        DayLength = c.String(),
                        YearLength = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planets");
        }
    }
}
