namespace DataSpace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Planets", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Planets", "PlanetType", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Planets", "DistanceFromSun", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Planets", "Diameter", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Planets", "DayLength", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Planets", "YearLength", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Planets", "YearLength", c => c.String());
            AlterColumn("dbo.Planets", "DayLength", c => c.String());
            AlterColumn("dbo.Planets", "Diameter", c => c.String());
            AlterColumn("dbo.Planets", "DistanceFromSun", c => c.String());
            AlterColumn("dbo.Planets", "PlanetType", c => c.String());
            AlterColumn("dbo.Planets", "Name", c => c.String());
        }
    }
}
