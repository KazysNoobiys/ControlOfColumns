using System.Data.Entity;
using ControlOfColumns.DAL.Models;
using ControlOfColumns.DAL.Utils;

namespace ControlOfColumns.DAL.EF
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}