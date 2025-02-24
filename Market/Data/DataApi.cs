using Microsoft.EntityFrameworkCore;
using Market.Models;
using System.Diagnostics.CodeAnalysis;

namespace Market.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product>  Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public ApplicationContext() => Database.EnsureCreated();


        public ApplicationContext(DbContextOptions dbOptions) : base(dbOptions)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static readonly ILoggerFactory LoggerFactory = new LoggerFactory();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=marketdb;Username=postgres;Password=postgres");

        }
    }
}
