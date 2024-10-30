﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pablo_Yanez_Examen1.Data;

#nullable disable

namespace Pablo_Yanez_Examen1.Migrations
{
    [DbContext(typeof(Pablo_Yanez_Examen1Context))]
    [Migration("20241030140020_Pablo_Yanez_Examen1")]
    partial class Pablo_Yanez_Examen1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pablo_Yanez_Examen1.Models.Celular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PYanezId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PYanezId")
                        .IsUnique();

                    b.ToTable("Celular");
                });

            modelBuilder.Entity("Pablo_Yanez_Examen1.Models.PYanez", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Sueldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PYanez");
                });

            modelBuilder.Entity("Pablo_Yanez_Examen1.Models.Celular", b =>
                {
                    b.HasOne("Pablo_Yanez_Examen1.Models.PYanez", "pYanez")
                        .WithOne("celular")
                        .HasForeignKey("Pablo_Yanez_Examen1.Models.Celular", "PYanezId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pYanez");
                });

            modelBuilder.Entity("Pablo_Yanez_Examen1.Models.PYanez", b =>
                {
                    b.Navigation("celular")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
