﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentProcessorFiled.Data;

namespace PaymentProcessorFiled.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210218092127_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PaymentProcessorFiled.Domains.Payment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentStateId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("varchar(3) CHARACTER SET utf8mb4")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("PaymentStateId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaymentProcessorFiled.Domains.PaymentState", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("PayState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("PaymentId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("paymentStates");
                });

            modelBuilder.Entity("PaymentProcessorFiled.Domains.Payment", b =>
                {
                    b.HasOne("PaymentProcessorFiled.Domains.PaymentState", "PaymentState")
                        .WithOne("Payment")
                        .HasForeignKey("PaymentProcessorFiled.Domains.Payment", "PaymentStateId");
                });
#pragma warning restore 612, 618
        }
    }
}
