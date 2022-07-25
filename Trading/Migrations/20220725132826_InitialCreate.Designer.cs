﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradingApp.Models;

#nullable disable

namespace Trading.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220725132826_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TradingApp.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lastname");

                    b.Property<int>("User_id")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("TradingApp.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Close_datetime")
                        .HasColumnType("datetime2")
                        .HasColumnName("close_datetime");

                    b.Property<int>("Close_price")
                        .HasColumnType("int")
                        .HasColumnName("close_price");

                    b.Property<bool>("Open")
                        .HasColumnType("bit")
                        .HasColumnName("open");

                    b.Property<DateTime>("Open_datetime")
                        .HasColumnType("datetime2")
                        .HasColumnName("open_datetime");

                    b.Property<int>("Open_price")
                        .HasColumnType("int")
                        .HasColumnName("open_price");

                    b.Property<int>("Profile_id")
                        .HasColumnType("int")
                        .HasColumnName("profile_id");

                    b.Property<int>("Quanity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.ToTable("Trade", (string)null);
                });

            modelBuilder.Entity("TradingApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TradingApp.Models.Wire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<int>("Profile_id")
                        .HasColumnType("int")
                        .HasColumnName("profile_id");

                    b.Property<bool>("Withdrawal")
                        .HasColumnType("bit")
                        .HasColumnName("withdrawal");

                    b.HasKey("Id");

                    b.ToTable("Wire", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}