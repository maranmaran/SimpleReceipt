using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Configurations;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Cafe> Cafes { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Table> Tables { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceTable> PriceTables { get; set; }

        public DbSet<PriceTableQuery> PriceTableQueries { get; set; }
        public DbSet<WaiterCafe> WaiterCafes { get; set; }
        public DbSet<ReceiptPriceTableQuery> ReceiptPriceTableQueries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Configuration
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new CafeConfiguration());

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());

            builder.ApplyConfiguration(new ReceiptConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new PriceTableConfiguration());

            builder.ApplyConfiguration(new PriceTableQueryConfiguration());
            builder.ApplyConfiguration(new WaiterCafeConfiguration());
            builder.ApplyConfiguration(new ReceiptPriceTableQueryConfiguration());
        }
    }
}
