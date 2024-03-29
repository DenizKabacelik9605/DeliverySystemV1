﻿// <auto-generated />
using System;
using DeliveryEntityframeworkCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryEntityframeworkCrud.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230416102814_AddDelivery2")]
    partial class AddDelivery2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeliveryEntityframeworkCrud.Delivery2", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeliveryId"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeliveryStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeliveryVehicleId")
                        .HasColumnType("integer");

                    b.HasKey("DeliveryId");

                    b.ToTable("deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
