using BikeStore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BikeStore.Entities;
using BikeStore.Data;

namespace BikeStore.Data
{
    public class BikeStoreContext : IdentityDbContext
    {
        public DbSet<BikeBrand> BikeBrands { get; set; }

        public DbSet<BikeModel> BikeModels { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public BikeStoreContext(DbContextOptions<BikeStoreContext> ctx)
            : base(ctx)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeBrand>()
                .HasMany(m => m.Models)
                .WithOne(r => r.Brand)
                .HasForeignKey(r => r.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
