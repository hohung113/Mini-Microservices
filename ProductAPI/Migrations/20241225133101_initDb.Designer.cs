﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.Data;

#nullable disable

namespace ProductAPI.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20241225133101_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductDescription = "A high-performance laptop ideal for work and entertainment.",
                            ProductName = "Laptop X Pro",
                            ProductPrice = 1500,
                            ProductStock = 25
                        },
                        new
                        {
                            ProductId = 2,
                            ProductDescription = "A cutting-edge smartphone with superior camera quality and long battery life.",
                            ProductName = "Smartphone Ultra",
                            ProductPrice = 1000,
                            ProductStock = 50
                        },
                        new
                        {
                            ProductId = 3,
                            ProductDescription = "Compact wireless earbuds offering immersive sound and active noise cancellation.",
                            ProductName = "Wireless Earbuds 360",
                            ProductPrice = 200,
                            ProductStock = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
