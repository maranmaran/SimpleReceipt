using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Receipts)
                .WithOne(y => y.Waiter);

            builder
                .HasOne(x => x.Cafe)
                .WithMany(y => y.Waiters)
                .HasForeignKey(z => z.CafeId);
        }
    }
}
