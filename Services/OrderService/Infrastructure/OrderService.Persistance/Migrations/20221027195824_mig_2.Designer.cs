﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderService.Persistance.Context;

#nullable disable

namespace OrderService.Persistance.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20221027195824_mig_2")]
    partial class mig_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Common.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("OrderService.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerIdentityId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalProductPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Common.Entities.OrderProduct", b =>
                {
                    b.HasOne("OrderService.Domain.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("OrderService.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
