using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataSpace.Models
{
    public class Planet
    {
        public int ID { get; set; }
        
        public string Picture { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Planet Type")]
        [Required]
        [StringLength(30)]
        public string PlanetType { get; set; }

        [Display(Name = "Distance from Sun")]
        [Required]
        [StringLength(30)]
        public string DistanceFromSun { get; set; }

        [Display(Name = "Diameter of Equator")]
        [Required]
        [StringLength(30)]
        public string Diameter { get; set; }

        [Display(Name = "Length of Day")]
        [Required]
        [StringLength(30)]
        public string DayLength { get; set; }

        [Display(Name = "Length of Year")]
        [Required]
        [StringLength(30)]
        public string YearLength { get; set; }
    }

    public class PlanetDBContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
    }
}