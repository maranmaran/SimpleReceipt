using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class CafeConfiguration : IEntityTypeConfiguration<Cafe>
    {
        public void Configure(EntityTypeBuilder<Cafe> builder)
        {
            builder
                .HasOne(x => x.PriceTable)
                .WithOne(y => y.Cafe)
                .HasForeignKey<PriceTable>(z => z.CafeId);

            builder
                .HasMany(x => x.Waiters)
                .WithOne(y => y.Cafe);

            builder
                .HasMany(x => x.Tables)
                .WithOne(y => y.Cafe);

            builder
                .HasMany(x => x.Receipts)
                .WithOne(y => y.Cafe);
        }
    }
}
