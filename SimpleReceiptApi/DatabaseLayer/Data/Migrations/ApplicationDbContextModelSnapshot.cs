﻿// <auto-generated />
using System;
using DatabaseLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseLayer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Cafe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cafes");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DatabaseLayer.Models.PriceTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CafeId");

                    b.HasKey("Id");

                    b.HasIndex("CafeId")
                        .IsUnique();

                    b.ToTable("PriceTables");
                });

            modelBuilder.Entity("DatabaseLayer.Models.PriceTableQuery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price");

                    b.Property<long>("PriceTableId");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("PriceTableId");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceTableQueries");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId");

                    b.Property<string>("Name");

                    b.Property<long>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Receipt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CafeId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("TableId");

                    b.Property<double>("Total");

                    b.Property<string>("WaiterId");

                    b.HasKey("Id");

                    b.HasIndex("CafeId");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ReceiptPriceTableQuery", b =>
                {
                    b.Property<long>("ReceiptId");

                    b.Property<long>("PriceTableQueryId");

                    b.Property<long>("Quantity");

                    b.HasKey("ReceiptId", "PriceTableQueryId");

                    b.HasIndex("PriceTableQueryId");

                    b.ToTable("ReceiptPriceTableQueries");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CafeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CafeId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("DatabaseLayer.Models.WaiterCafe", b =>
                {
                    b.Property<string>("WaiterId");

                    b.Property<long>("CafeId");

                    b.HasKey("WaiterId", "CafeId");

                    b.HasIndex("CafeId");

                    b.ToTable("WaiterCafes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Cafe", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Company", "Company")
                        .WithMany("Cafes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseLayer.Models.PriceTable", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Cafe", "Cafe")
                        .WithOne("PriceTable")
                        .HasForeignKey("DatabaseLayer.Models.PriceTable", "CafeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseLayer.Models.PriceTableQuery", b =>
                {
                    b.HasOne("DatabaseLayer.Models.PriceTable", "PriceTable")
                        .WithMany("PriceTableQueries")
                        .HasForeignKey("PriceTableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Models.Product", "Product")
                        .WithMany("PriceTableQueries")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseLayer.Models.Product", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseLayer.Models.Receipt", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Cafe", "Cafe")
                        .WithMany("Receipts")
                        .HasForeignKey("CafeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Models.Table", "Table")
                        .WithMany("Receipts")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseLayer.Models.ApplicationUser", "Waiter")
                        .WithMany("Receipts")
                        .HasForeignKey("WaiterId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ReceiptPriceTableQuery", b =>
                {
                    b.HasOne("DatabaseLayer.Models.PriceTableQuery", "PriceTableQuery")
                        .WithMany("ReceiptPriceTableQueries")
                        .HasForeignKey("PriceTableQueryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Models.Receipt", "Receipt")
                        .WithMany("ReceiptPriceTableQueries")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseLayer.Models.Table", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Cafe", "Cafe")
                        .WithMany("Tables")
                        .HasForeignKey("CafeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseLayer.Models.WaiterCafe", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Cafe", "Cafe")
                        .WithMany("Waiters")
                        .HasForeignKey("CafeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Models.ApplicationUser", "Waiter")
                        .WithMany("Cafes")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
