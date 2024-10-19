﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTicker.Models;

#nullable disable

namespace StockTicker.Migrations
{
    [DbContext(typeof(MariaDbContext))]
    partial class MariaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StockTicker.Models.Overview", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Overviews");
                });

            modelBuilder.Entity("StockTicker.Models.OverviewStockTickerItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OverviewID")
                        .HasColumnType("int");

                    b.Property<int>("StockTickerItemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OverviewID");

                    b.HasIndex("StockTickerItemID");

                    b.ToTable("OverviewsStockTickerItems");
                });

            modelBuilder.Entity("StockTicker.Models.StockTickerItem", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("ID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("StockTickerItems");
                });

            modelBuilder.Entity("StockTicker.Models.OverviewStockTickerItem", b =>
                {
                    b.HasOne("StockTicker.Models.Overview", "Overview")
                        .WithMany("Items")
                        .HasForeignKey("OverviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockTicker.Models.StockTickerItem", "StockTickerItem")
                        .WithMany("OverviewStockTickerItems")
                        .HasForeignKey("StockTickerItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Overview");

                    b.Navigation("StockTickerItem");
                });

            modelBuilder.Entity("StockTicker.Models.Overview", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("StockTicker.Models.StockTickerItem", b =>
                {
                    b.Navigation("OverviewStockTickerItems");
                });
#pragma warning restore 612, 618
        }
    }
}
