using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sport.Models;
using Microsoft.EntityFrameworkCore;

namespace Sport.Data
{
    public class SpordiContext : DbContext
    {
        public SpordiContext(DbContextOptions<SpordiContext> options) : base(options)
        {
        }

        public DbSet<Spordiala> Spordiala { get; set; }
        public DbSet<Registreering> Registreeringud { get; set; }
        public DbSet<Sportlane> Sportlased { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spordiala>().ToTable("Spordiala");
            modelBuilder.Entity<Registreering>().ToTable("Registreering");
            modelBuilder.Entity<Sportlane>().ToTable("Sportlane");
        }
    }
}
