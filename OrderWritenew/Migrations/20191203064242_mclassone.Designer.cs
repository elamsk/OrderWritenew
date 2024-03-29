﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderWritenew.Repository;

namespace OrderWritenew.Migrations
{
    [DbContext(typeof(OrderDBContext))]
    [Migration("20191203064242_mclassone")]
    partial class mclassone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderWritenew.Models.Order", b =>
                {
                    b.Property<int>("Orderid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Orderdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Orderid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("OrderWritenew.Models.Order", b =>
                {
                    b.OwnsOne("OrderWritenew.Models.CustomerName", "Customer", b1 =>
                        {
                            b1.Property<int>("Orderid")
                                .HasColumnType("int");

                            b1.Property<string>("Firstname")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Lastname")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Location")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Orderid");

                            b1.ToTable("CustomerInfo");

                            b1.WithOwner()
                                .HasForeignKey("Orderid");
                        });

                    b.OwnsMany("OrderWritenew.Models.OrderLineItems", "OrderItems", b1 =>
                        {
                            b1.Property<int>("OrderLineItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Orderid")
                                .HasColumnType("int");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("OrderLineItemId");

                            b1.HasIndex("Orderid");

                            b1.ToTable("OrderLineItems");

                            b1.WithOwner()
                                .HasForeignKey("Orderid");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
