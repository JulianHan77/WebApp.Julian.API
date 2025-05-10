using Microsoft.EntityFrameworkCore;
using WebApp.Julian.Domain.Entities;

namespace WebApp.Julian.Infrastucture.Context
{
    public class WebAppJulianDbContext(DbContextOptions<WebAppJulianDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    //modelBuilder.Entity<Product>()
        //    //    .OwnsMany(r = r.Products);
        //}
    }
}
