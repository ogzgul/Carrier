﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CarrierContext))]
    [Migration("20230331104849_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.Carrier", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierId"));

                    b.Property<int>("CarrierConfigurationId")
                        .HasColumnType("int");

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("CarrierId");

                    b.HasIndex("CarrierConfigurationId");

                    b.ToTable("Carriers");

                    b.HasData(
                        new
                        {
                            CarrierId = 1,
                            CarrierConfigurationId = 1,
                            CarrierIsActive = true,
                            CarrierName = "Aras",
                            CarrierPlusDesiCost = 10
                        });
                });

            modelBuilder.Entity("Entities.Concrete.CarrierConfiguration", b =>
                {
                    b.Property<int>("CarrierConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierConfigurationId"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.HasKey("CarrierConfigurationId");

                    b.ToTable("CarrierConfigurations");

                    b.HasData(
                        new
                        {
                            CarrierConfigurationId = 1,
                            CarrierCost = 40.00m,
                            CarrierId = 1,
                            CarrierMaxDesi = 20,
                            CarrierMinDesi = 2
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CarrierId = 1,
                            OrderCarrierCost = 50.00m,
                            OrderDate = new DateTime(2023, 3, 31, 13, 48, 49, 745, DateTimeKind.Local).AddTicks(1965),
                            OrderDesi = 10
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Carrier", b =>
                {
                    b.HasOne("Entities.Concrete.CarrierConfiguration", "CarrierConfiguration")
                        .WithMany()
                        .HasForeignKey("CarrierConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrierConfiguration");
                });
#pragma warning restore 612, 618
        }
    }
}