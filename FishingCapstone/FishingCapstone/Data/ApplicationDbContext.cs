using System;
using System.Collections.Generic;
using System.Text;
using FishingCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
       .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Name = "Explorer",
                NormalizedName = "EXPLORER",
            }
                );
            builder.Entity<Destination>()
                .HasData(
                    new Destination { DestinationId = 1, DestinationName = "Cabo San Lucas, MX", DestinationLat = "22.8822", DestinationLong = "-109.91203" },
                    new Destination { DestinationId = 2, DestinationName = "Cozumel, MX", DestinationLat = "20.468355", DestinationLong = "-86.978845" },
                    new Destination { DestinationId = 3, DestinationName = "La Paz, MX", DestinationLat = "24.167785", DestinationLong = "-110.310101" },
                    new Destination { DestinationId = 4, DestinationName = "West Bend, WI", DestinationLat = "43.412800", DestinationLong = "-88.189249" }
                );
            builder.Entity<Month>()
                .HasData(
                    new Month { MonthId = 1, MonthName = "January" },
                    new Month { MonthId = 2, MonthName = "February" },
                    new Month { MonthId = 3, MonthName = "March" },
                    new Month { MonthId = 4, MonthName = "April" },
                    new Month { MonthId = 5, MonthName = "May" },
                    new Month { MonthId = 6, MonthName = "June" },
                    new Month { MonthId = 7, MonthName = "July" },
                    new Month { MonthId = 8, MonthName = "August" },
                    new Month { MonthId = 9, MonthName = "September" },
                    new Month { MonthId = 10, MonthName = "October" },
                    new Month { MonthId = 11, MonthName = "November" },
                    new Month { MonthId = 12, MonthName = "December" }
                        );
            builder.Entity<Rating>()
                .HasData(
                    new Rating { RatingId = 1, RatingName = "Poor", RatingNumber = 1 },
                    new Rating { RatingId = 2, RatingName = "Fair", RatingNumber = 2 },
                    new Rating { RatingId = 3, RatingName = "Good", RatingNumber = 3 },
                    new Rating { RatingId = 4, RatingName = "Best", RatingNumber = 4 }
                );
            builder.Entity<Species>()
                .HasData(
                    new Species { SpeciesId = 1, SpeciesName = "Amberjack" },
                    new Species { SpeciesId = 2, SpeciesName = "Barracuda" },
                    new Species { SpeciesId = 3, SpeciesName = "Bonito" },
                    new Species { SpeciesId = 4, SpeciesName = "Cabrilla" },
                    new Species { SpeciesId = 5, SpeciesName = "Grouper" },
                    new Species { SpeciesId = 6, SpeciesName = "Jack Crevalle" },
                    new Species { SpeciesId = 7, SpeciesName = "Kingfish" },
                    new Species { SpeciesId = 8, SpeciesName = "Mackerel - Sierra" },
                    new Species { SpeciesId = 9, SpeciesName = "Mahi Mahi - Dorado" },
                    new Species { SpeciesId = 10, SpeciesName = "Marlin -Black" },
                    new Species { SpeciesId = 11, SpeciesName = "Marlin - Blue" },
                    new Species { SpeciesId = 12, SpeciesName = "Marlin - Striped" },
                    new Species { SpeciesId = 13, SpeciesName = "Marlin - White" },
                    new Species { SpeciesId = 14, SpeciesName = "Pargo - Dogtooth Snapper" },
                    new Species { SpeciesId = 15, SpeciesName = "Red Snapper" },
                    new Species { SpeciesId = 16, SpeciesName = "Roosterfish" },
                    new Species { SpeciesId = 17, SpeciesName = "Sailfish" },
                    new Species { SpeciesId = 18, SpeciesName = "Shark" },
                    new Species { SpeciesId = 19, SpeciesName = "Skipjack" },
                    new Species { SpeciesId = 20, SpeciesName = "Snook" },
                    new Species { SpeciesId = 21, SpeciesName = "Tuna" },
                    new Species { SpeciesId = 22, SpeciesName = "Wahoo" },
                    new Species { SpeciesId = 23, SpeciesName = "Yellowtail" }
                );
            //builder.Entity<DestSpeciesMonth>()
            //    .HasData(
            //        new DestSpeciesMonth { DestSpeciesMonthId = 1, DSMDestinationId = 222222, DSMSpeciesId = 3333333, DSMMonthId = 3333333, DSMRatingId = 3333333 },
            //        new Rating { RatingId = 2, RatingName = "Fair", RatingNumber = 2 },
            //        new Rating { RatingId = 3, RatingName = "Good", RatingNumber = 3 },
            //        new Rating { RatingId = 4, RatingName = "Best", RatingNumber = 4 }
            //    );
        }
        public DbSet<FishingCapstone.Models.Admin> Admin { get; set; }
        public DbSet<FishingCapstone.Models.Explorer> Explorer { get; set; }
        public DbSet<FishingCapstone.Models.Destination> Destination { get; set; }
        public DbSet<FishingCapstone.Models.Month> Month { get; set; }
        public DbSet<FishingCapstone.Models.Rating> Rating { get; set; }
        public DbSet<FishingCapstone.Models.Species> Species { get; set; }
        //public DbSet<FishingCapstone.Models.DestSpeciesMonth> DestSpeciesMonth { get; set; }








    }
}
