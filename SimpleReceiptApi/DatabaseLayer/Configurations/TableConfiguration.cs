using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder
                .HasOne(x => x.Cafe)
                .WithMany(y => y.Tables)
                .HasForeignKey(z => z.CafeId);

            builder
                .HasMany(x => x.Receipts)
                .WithOne(y => y.Table);
        }
    }
}
