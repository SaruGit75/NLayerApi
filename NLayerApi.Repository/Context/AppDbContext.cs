using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApi.Core.Models;

namespace NLayerApi.Repository.Context
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Startuptan connection str. verebilmek icin bu yapilmali.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hepsini birden bind ediyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature()
                {
                    Id = 1,
                    Color = "Red",
                    Height = 100,
                    Width = 123,
                    ProductId = 1
                },
                new ProductFeature()
                {
                    Id = 2,
                    Color = "Blue",
                    Height = 100,
                    Width = 123,
                    ProductId = 2
                }
            );
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
    }
}
