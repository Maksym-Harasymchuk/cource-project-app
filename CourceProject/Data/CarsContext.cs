using CourceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourceProject.Entities
{
    public class CarsContext : IdentityDbContext<User>
    {
        public CarsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Favourite> FavouritesCars { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var converter = new ValueConverter<string, string>(
                v => v.ToUpper(), // writing
                v => v
            );

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole {Name = "Member", NormalizedName = "MEMBER"},
                    new IdentityRole {Name = "Admin", NormalizedName = "ADMIN"}
                );
        }
    }
}