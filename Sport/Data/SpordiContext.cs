using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport.Data
{
    public class SpordiContext : DBContext
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
