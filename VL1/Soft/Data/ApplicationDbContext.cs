using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VL1.Infra.Quantity;
using Facade.Quantity;

namespace Soft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            QuantityDbContext.InitializeTables(builder);
        }
        public DbSet<Facade.Quantity.MeasureView> MeasureView { get; set; }
    }
}
