using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebAPIDemo.Model;

namespace WebAPIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding
            modelBuilder.Entity<Shirt>().HasData(
                 new Shirt { ShirtId = 1, Brand = "Red Shirt", Color = "Red", Size = 8, Gender = "Men", Price = 29.99 },
                 new Shirt { ShirtId = 2, Brand = "Blue Shirt", Color = "Blue", Size = 6, Gender = "Women", Price = 19.99 },
                 new Shirt { ShirtId = 3, Brand = "Green Shirt", Color = "Green", Size = 12, Gender = "Men", Price = 39.99 }
            );
        }       
    }
}
