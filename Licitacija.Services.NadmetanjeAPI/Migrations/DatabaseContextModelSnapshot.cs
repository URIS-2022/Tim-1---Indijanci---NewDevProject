﻿// <auto-generated />
using System;
using Licitacija.Services.UplataAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.NadmetanjeAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.Javno", b =>
                {
                    b.Property<Guid>("JavnoNadmetanjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EtapaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NadmetanjeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JavnoNadmetanjeId");

                    b.HasIndex("NadmetanjeId")
                        .IsUnique();

                    b.ToTable("Javno");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.Nadmetanje", b =>
                {
                    b.Property<Guid>("NadmetanjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojUcesnika")
                        .HasColumnType("int");

                    b.Property<int>("CenaPoHektaru")
                        .HasColumnType("int");

                    b.Property<Guid>("FazaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IzlicitiranaCena")
                        .HasColumnType("int");

                    b.Property<bool>("Izuzeto")
                        .HasColumnType("bit");

                    b.Property<Guid>("KadOpstinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Krug")
                        .HasColumnType("int");

                    b.Property<Guid>("LicitacijaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PeriodZakupa")
                        .HasColumnType("int");

                    b.Property<Guid>("StatusNadmetanjaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VisinaDopuneDepozita")
                        .HasColumnType("int");

                    b.Property<DateTime>("VremeKraja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremePocetka")
                        .HasColumnType("datetime2");

                    b.HasKey("NadmetanjeId");

                    b.HasIndex("StatusNadmetanjaId");

                    b.ToTable("Nadmetanje");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.OtvaranjePonuda", b =>
                {
                    b.Property<Guid>("OtvaranjePonudaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NadmetanjeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OtvaranjePonudaId");

                    b.HasIndex("NadmetanjeId")
                        .IsUnique();

                    b.ToTable("OtvaranjePonuda");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.StatusNadmetanja", b =>
                {
                    b.Property<Guid>("StatusNadmetanjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusNadmetanjaNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusNadmetanjaId");

                    b.ToTable("StatusNadmetanja");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.Javno", b =>
                {
                    b.HasOne("Licitacija.Services.NadmetanjeAPI.Entities.Nadmetanje", "Nadmetanje")
                        .WithOne("Javno")
                        .HasForeignKey("Licitacija.Services.NadmetanjeAPI.Entities.Javno", "NadmetanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nadmetanje");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.Nadmetanje", b =>
                {
                    b.HasOne("Licitacija.Services.NadmetanjeAPI.Entities.StatusNadmetanja", "StatusNadmetanja")
                        .WithMany("Nadmetanja")
                        .HasForeignKey("StatusNadmetanjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusNadmetanja");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.OtvaranjePonuda", b =>
                {
                    b.HasOne("Licitacija.Services.NadmetanjeAPI.Entities.Nadmetanje", null)
                        .WithOne("OtvaranjePonuda")
                        .HasForeignKey("Licitacija.Services.NadmetanjeAPI.Entities.OtvaranjePonuda", "NadmetanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.Nadmetanje", b =>
                {
                    b.Navigation("Javno");

                    b.Navigation("OtvaranjePonuda");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeAPI.Entities.StatusNadmetanja", b =>
                {
                    b.Navigation("Nadmetanja");
                });
#pragma warning restore 612, 618
        }
    }
}
