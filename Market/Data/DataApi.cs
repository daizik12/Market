using Microsoft.EntityFrameworkCore;
using Market.Models;

namespace Market.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product>  Products { get; set; }
        public ApplicationContext() => Database.EnsureCreated();
        public ApplicationContext(DbContextOptions dbOptions) :base(dbOptions)
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=marketdb;Username=postgres;Password=postgres");
        }
    }
}
