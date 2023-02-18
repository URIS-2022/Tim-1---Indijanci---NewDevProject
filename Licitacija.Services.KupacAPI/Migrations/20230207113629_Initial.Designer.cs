﻿// <auto-generated />
using System;
using Licitacija.Services.KupacAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230207113629_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.FizickoLice", b =>
                {
                    b.Property<Guid>("FizickoLiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FizickoLiceIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FizickoLicePrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("KupacId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FizickoLiceId");

                    b.HasIndex("JMBG")
                        .IsUnique();

                    b.HasIndex("KupacId")
                        .IsUnique();

                    b.ToTable("FizickoLice");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.KontaktOsoba", b =>
                {
                    b.Property<Guid>("KontaktOsobaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktOsobaIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktOsobaPrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontaktOsobaId");

                    b.ToTable("KontaktOsoba");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.Kupac", b =>
                {
                    b.Property<Guid>("KupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTel1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTel2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumPocetkaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPrestankaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DuzinaTrajanjaZabrane")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ImaZabranu")
                        .HasColumnType("bit");

                    b.Property<int>("OstvarenPovrsina")
                        .HasColumnType("int");

                    b.Property<Guid?>("PrioritetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KupacId");

                    b.HasIndex("PrioritetId");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.PravnoLice", b =>
                {
                    b.Property<Guid>("PravnoLiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Faks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KontaktOsobaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KupacId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaticniBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PravnoLiceNazv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PravnoLiceId");

                    b.HasIndex("KontaktOsobaId");

                    b.HasIndex("KupacId")
                        .IsUnique();

                    b.HasIndex("MaticniBroj")
                        .IsUnique();

                    b.ToTable("PravnoLice");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.Prioritet", b =>
                {
                    b.Property<Guid>("PrioritetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrioritetNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PrioritetId");

                    b.HasIndex("PrioritetNaziv")
                        .IsUnique();

                    b.ToTable("Prioritet");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.FizickoLice", b =>
                {
                    b.HasOne("Licitacija.Services.KupacAPI.Entities.Kupac", "Kupac")
                        .WithOne("FizickoLice")
                        .HasForeignKey("Licitacija.Services.KupacAPI.Entities.FizickoLice", "KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.Kupac", b =>
                {
                    b.HasOne("Licitacija.Services.KupacAPI.Entities.Prioritet", "Prioritet")
                        .WithMany("Kupac")
                        .HasForeignKey("PrioritetId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Prioritet");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.PravnoLice", b =>
                {
                    b.HasOne("Licitacija.Services.KupacAPI.Entities.KontaktOsoba", "KontaktOsoba")
                        .WithMany("PravnoLice")
                        .HasForeignKey("KontaktOsobaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Licitacija.Services.KupacAPI.Entities.Kupac", "Kupac")
                        .WithOne("PravnoLice")
                        .HasForeignKey("Licitacija.Services.KupacAPI.Entities.PravnoLice", "KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KontaktOsoba");

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.KontaktOsoba", b =>
                {
                    b.Navigation("PravnoLice");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.Kupac", b =>
                {
                    b.Navigation("FizickoLice");

                    b.Navigation("PravnoLice");
                });

            modelBuilder.Entity("Licitacija.Services.KupacAPI.Entities.Prioritet", b =>
                {
                    b.Navigation("Kupac");
                });
#pragma warning restore 612, 618
        }
    }
}
