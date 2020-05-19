﻿// <auto-generated />
using System;
using BitsAndBobs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BitsAndBobs.Data.Migrations
{
    [DbContext(typeof(BitsAndBobsContext))]
    [Migration("20200519051633_CurrencyUpdate")]
    partial class CurrencyUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BitsAndBobs.BuildModels.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("CustomersDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventoryLocationLocationID")
                        .HasColumnType("int");

                    b.Property<int>("InventoryProductProductID")
                        .HasColumnType("int");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.HasKey("InventoryID");

                    b.HasIndex("InventoryLocationLocationID");

                    b.HasIndex("InventoryProductProductID");

                    b.ToTable("InventoryDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("LocationsDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderCustomerCustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderLocationLocationID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderCustomerCustomerID");

                    b.HasIndex("OrderLocationLocationID");

                    b.ToTable("OrdersDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.OrderLineItem", b =>
                {
                    b.Property<int>("OrderLineItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LineItemProductProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("LinePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderLineItemID");

                    b.HasIndex("LineItemProductProductID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderLineItemsDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("ProductsDB");
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Inventory", b =>
                {
                    b.HasOne("BitsAndBobs.BuildModels.Location", "InventoryLocation")
                        .WithMany()
                        .HasForeignKey("InventoryLocationLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitsAndBobs.BuildModels.Product", "InventoryProduct")
                        .WithMany()
                        .HasForeignKey("InventoryProductProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.Order", b =>
                {
                    b.HasOne("BitsAndBobs.BuildModels.Customer", "OrderCustomer")
                        .WithMany()
                        .HasForeignKey("OrderCustomerCustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitsAndBobs.BuildModels.Location", "OrderLocation")
                        .WithMany()
                        .HasForeignKey("OrderLocationLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BitsAndBobs.BuildModels.OrderLineItem", b =>
                {
                    b.HasOne("BitsAndBobs.BuildModels.Product", "LineItemProduct")
                        .WithMany()
                        .HasForeignKey("LineItemProductProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitsAndBobs.BuildModels.Order", null)
                        .WithMany("OrderLineItems")
                        .HasForeignKey("OrderID");
                });
#pragma warning restore 612, 618
        }
    }
}
