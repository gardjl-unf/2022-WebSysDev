﻿// <auto-generated />
using System;
using COP3855_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace COP3855_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221030161539_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("COP3855_Project.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderID");

                    b.HasIndex("VehicleID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("COP3855_Project.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GiftWrap")
                        .HasColumnType("bit");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("COP3855_Project.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccMobileConnect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccWallConnect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnhancedAutopilot")
                        .HasColumnType("bit");

                    b.Property<string>("ExteriorColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FullSelfDriving")
                        .HasColumnType("bit");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InteriorColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wheels")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vehicles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicle");
                });

            modelBuilder.Entity("COP3855_Project.Models.Model3", b =>
                {
                    b.HasBaseType("COP3855_Project.Models.Vehicle");

                    b.HasDiscriminator().HasValue("Model3");
                });

            modelBuilder.Entity("COP3855_Project.Models.ModelS", b =>
                {
                    b.HasBaseType("COP3855_Project.Models.Vehicle");

                    b.Property<bool>("SPerformancePackage")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("ModelS");
                });

            modelBuilder.Entity("COP3855_Project.Models.ModelX", b =>
                {
                    b.HasBaseType("COP3855_Project.Models.Vehicle");

                    b.Property<int>("Seating")
                        .HasColumnType("int");

                    b.Property<bool>("XPerformancePackage")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("ModelX");
                });

            modelBuilder.Entity("COP3855_Project.Models.ModelY", b =>
                {
                    b.HasBaseType("COP3855_Project.Models.Vehicle");

                    b.Property<int>("Seating")
                        .HasColumnName("ModelY_Seating")
                        .HasColumnType("int");

                    b.Property<bool>("TowHitch")
                        .HasColumnType("bit");

                    b.Property<bool>("YPerformancePackage")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("ModelY");
                });

            modelBuilder.Entity("COP3855_Project.Models.CartLine", b =>
                {
                    b.HasOne("COP3855_Project.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("COP3855_Project.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID");
                });
#pragma warning restore 612, 618
        }
    }
}
