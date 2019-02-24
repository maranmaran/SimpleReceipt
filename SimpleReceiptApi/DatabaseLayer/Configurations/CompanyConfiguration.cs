using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .HasMany(x => x.Products)
                .WithOne(y => y.Company);

            builder
                .HasMany(x => x.Cafes)
                .WithOne(y => y.Company);
        }
    }
}
