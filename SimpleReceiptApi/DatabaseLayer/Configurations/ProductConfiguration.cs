using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(x => x.Company)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.CompanyId);

            builder
                .HasMany(x => x.PriceTableQueries)
                .WithOne(y => y.Product)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
