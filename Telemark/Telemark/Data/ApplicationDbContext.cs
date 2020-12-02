using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Telemark.Models;

namespace Telemark.Data
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
                NormalizedName = "ADMIN"
            }
            );
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Director",
                NormalizedName = "DIRECTOR"
            }
            );
        }
        public DbSet<Telemark.Models.Director> Directors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<SmsMessage> Messages { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TextUser> TextUsers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<InfoMessage> Info { get; set; }
        public DbSet<RaceAddress> RaceAddresses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PushResult> PushResults { get; set; }

        public DbSet<>

    }
}
