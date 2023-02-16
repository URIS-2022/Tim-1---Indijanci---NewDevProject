﻿// <auto-generated />
using System;
using Licitacija.Services.NadmetanjeKupacAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.NadmetanjeKupacAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.NadmetanjeKupacAPI.Entities.NadmetanjeKupacEntity", b =>
                {
                    b.Property<Guid>("NadmetanjeKupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KupacId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NadmetanjeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OvlascenoLiceId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NadmetanjeKupacId");

                    b.HasIndex("OvlascenoLiceId");

                    b.ToTable("NadmetanjeKupac");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeKupacAPI.Entities.OvlascenoLice", b =>
                {
                    b.Property<Guid>("OvlascenoLiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojPasosa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OvlascenoLiceId");

                    b.ToTable("OvlascenoLice");
                });

            modelBuilder.Entity("Licitacija.Services.NadmetanjeKupacAPI.Entities.NadmetanjeKupacEntity", b =>
                {
                    b.HasOne("Licitacija.Services.NadmetanjeKupacAPI.Entities.OvlascenoLice", "OvlascenoLice")
                        .WithMany()
                        .HasForeignKey("OvlascenoLiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OvlascenoLice");
                });
#pragma warning restore 612, 618
        }
    }
}
