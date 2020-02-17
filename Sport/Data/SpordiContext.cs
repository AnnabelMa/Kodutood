using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sport.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity; seda kasutades lööb 14 errorit

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
        public DbSet<Osakond> Osakonnad { get; set; }
        public DbSet<Treener> Treenerid { get; set; }
        public DbSet<AsutuseAssignment> AsutuseAssignments { get; set; }
        public DbSet<SpordialaAssignment> SpordialaAssignments { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spordiala>().ToTable("Spordiala");
            modelBuilder.Entity<Registreering>().ToTable("Registreering");
            modelBuilder.Entity<Sportlane>().ToTable("Sportlane");

            modelBuilder.Entity<Osakond>().ToTable("Osakond");
            modelBuilder.Entity<Treener>().ToTable("Treener");
            modelBuilder.Entity<AsutuseAssignment>().ToTable("AsutuseAssignment");
            modelBuilder.Entity<SpordialaAssignment>().ToTable("SpordialaAssignment");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<SpordialaAssignment>()
                .HasKey(c => new { c.SpordialaID, c.TreenerID });
        }
    }
}
