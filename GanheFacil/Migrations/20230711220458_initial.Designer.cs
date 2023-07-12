﻿// <auto-generated />
using System;
using GanheFacil.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GanheFacil.Migrations
{
    [DbContext(typeof(GanheFacilContext))]
    [Migration("20230711220458_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GanheFacil.Models.Resultado", b =>
                {
                    b.Property<DateTime>("DataSorteio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPremio")
                        .HasColumnType("decimal(18, 2)");

                    b.ToTable("Resultados", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}