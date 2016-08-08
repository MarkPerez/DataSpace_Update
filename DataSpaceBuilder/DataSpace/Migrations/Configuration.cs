namespace DataSpace.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataSpace.Models.PlanetDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataSpace.Models.PlanetDBContext context)
        {
            context.Planets.AddOrUpdate(i => i.Name,
                new Planet
                {
                    Picture = "https://pixabay.com/static/uploads/photo/2012/01/09/09/33/mercury-11591__180.png",
                    Name = "Mercury",
                    PlanetType = "Terrestrial Planet",
                    DistanceFromSun = "58 million km",
                    Diameter = "4,880 km",
                    DayLength = "59 days",
                    YearLength = "88 days"

                }
            );
        }
    }
}
