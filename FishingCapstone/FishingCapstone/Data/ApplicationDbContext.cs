using System;
using System.Collections.Generic;
using System.Text;
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
        }
        public DbSet<FishingCapstone.Models.Admin> Admin { get; set; }
        public DbSet<FishingCapstone.Models.Explorer> Explorer { get; set; }








    }
}
