using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class PriceTableConfiguration : IEntityTypeConfiguration<PriceTable>
    {
        public void Configure(EntityTypeBuilder<PriceTable> builder)
        {
     
            builder
                .HasMany(x => x.PriceTableQueries)
                .WithOne(y => y.PriceTable);
        }
    }
}
