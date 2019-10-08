﻿// <auto-generated />
using System;
using Majestic.Domain.MajesticContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Majestic.Domain.Migrations
{
    [DbContext(typeof(MajesticDbContext))]
    [Migration("20191003091627_cartssDetailsTableChanged")]
    partial class cartssDetailsTableChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Majestic.Models.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Majestic.Models.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("Majestic.Models.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("ApplicationId");

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("DateofOrder");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Quantity");

                    b.HasKey("CartId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProductId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Majestic.Models.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Majestic.Models.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Majestic.Models.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Majestic.Models.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("OrderId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Majestic.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Majestic.Models.Models.Address", b =>
                {
                    b.HasOne("Majestic.Models.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Majestic.Models.Models.Cart", b =>
                {
                    b.HasOne("Majestic.Models.Models.ApplicationUser", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Majestic.Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Majestic.Models.Models.Order", b =>
                {
                    b.HasOne("Majestic.Models.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Majestic.Models.Models.Product", b =>
                {
                    b.HasOne("Majestic.Models.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
