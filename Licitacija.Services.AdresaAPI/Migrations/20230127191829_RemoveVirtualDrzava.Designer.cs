﻿// <auto-generated />
using System;
using Licitacija.Services.AdresaAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.AdresaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230127191829_RemoveVirtualDrzava")]
    partial class RemoveVirtualDrzava
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.AdresaAPI.Entities.Adresa", b =>
                {
                    b.Property<Guid>("AdresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Broj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DrzavaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresaId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Adresa");
                });

            modelBuilder.Entity("Licitacija.Services.AdresaAPI.Entities.Drzava", b =>
                {
                    b.Property<Guid>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DrzavaNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DrzavaId");

                    b.HasIndex("DrzavaNaziv")
                        .IsUnique();

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("Licitacija.Services.AdresaAPI.Entities.Adresa", b =>
                {
                    b.HasOne("Licitacija.Services.AdresaAPI.Entities.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });
#pragma warning restore 612, 618
        }
    }
}
