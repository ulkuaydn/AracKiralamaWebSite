﻿// <auto-generated />
using System;
using AracKiralama.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AracKiralama.Migrations
{
    [DbContext(typeof(AracKiralamaContext))]
    [Migration("20250105202152_AracVerileri")]
    partial class AracVerileri
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AracKiralama.Models.Arac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("GunlukUcret")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Musait")
                        .HasColumnType("bit");

                    b.Property<string>("ResimUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vites")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YakitTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Arac", (string)null);
                });

            modelBuilder.Entity("AracKiralama.Models.Kiralama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AracId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamUcret")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("AracId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Kiralama", (string)null);
                });

            modelBuilder.Entity("AracKiralama.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriId"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriId");

                    b.ToTable("Musteri", (string)null);
                });

            modelBuilder.Entity("AracKiralama.Models.Kiralama", b =>
                {
                    b.HasOne("AracKiralama.Models.Arac", "Araba")
                        .WithMany()
                        .HasForeignKey("AracId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AracKiralama.Models.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Araba");

                    b.Navigation("Musteri");
                });
#pragma warning restore 612, 618
        }
    }
}
