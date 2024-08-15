﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.API.Infrastructure;

#nullable disable

namespace Ordering.API.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Ordering.API.Domain.OrderAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "submitted"
                        },
                        new
                        {
                            Id = 2,
                            Name = "awaitingvalidation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "stockconfirmed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "paid"
                        },
                        new
                        {
                            Id = 5,
                            Name = "shipped"
                        },
                        new
                        {
                            Id = 6,
                            Name = "cancelled"
                        });
                });

            modelBuilder.Entity("Ordering.API.Domain.OrderAgrregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(12,2)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Ordering.API.Domain.OrderAgrregate.Order.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Ordering.API.Domain.OrderAgrregate.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("varchar(24)");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Ordering.API.Domain.OrderAgrregate.Order", b =>
                {
                    b.HasOne("Ordering.API.Domain.OrderAggregate.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("Ordering.API.Domain.OrderAgrregate.OrderItem", b =>
                {
                    b.HasOne("Ordering.API.Domain.OrderAgrregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ordering.API.Domain.OrderAgrregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}