﻿// <auto-generated />
using System;
using Licitacija.Services.LicitacijaAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.LicitacijaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.LicitacijaAPI.Entities.FazaLicitacije", b =>
                {
                    b.Property<Guid>("FazaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FazaNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LicitacijaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FazaId");

                    b.HasIndex("LicitacijaId");

                    b.ToTable("FazaLicitacije");
                });

            modelBuilder.Entity("Licitacija.Services.LicitacijaAPI.Entities.LicitacijaEntity", b =>
                {
                    b.Property<Guid>("LicitacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Broj")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<int>("KorakCene")
                        .HasColumnType("int");

                    b.Property<int>("Ogranicenje")
                        .HasColumnType("int");

                    b.Property<DateTime>("RokZaPrijave")
                        .HasColumnType("datetime2");

                    b.HasKey("LicitacijaId");

                    b.ToTable("Licitacija");
                });

            modelBuilder.Entity("Licitacija.Services.LicitacijaAPI.Entities.FazaLicitacije", b =>
                {
                    b.HasOne("Licitacija.Services.LicitacijaAPI.Entities.LicitacijaEntity", "LicitacijaEntity")
                        .WithMany("FazaLicitacije")
                        .HasForeignKey("LicitacijaId");

                    b.Navigation("LicitacijaEntity");
                });

            modelBuilder.Entity("Licitacija.Services.LicitacijaAPI.Entities.LicitacijaEntity", b =>
                {
                    b.Navigation("FazaLicitacije");
                });
#pragma warning restore 612, 618
        }
    }
}
