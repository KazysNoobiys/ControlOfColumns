using System.Data.Entity.ModelConfiguration;
using ControlOfColumns.DAL.Models;

namespace ControlOfColumns.DAL.Utils
{
    public class ProductConfiguration:EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(product => product.Id);
            Property(product => product.Name).IsRequired().HasMaxLength(50);
            Property(product => product.Price).IsRequired();
            Property(product => product.Quantity).IsRequired();
        }
    }
}