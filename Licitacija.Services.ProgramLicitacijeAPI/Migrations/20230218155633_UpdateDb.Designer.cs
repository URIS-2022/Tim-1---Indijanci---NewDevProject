﻿// <auto-generated />
using System;
using Licitacija.Services.ProgramLicitacijeAPI.DbConexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.ProgramLicitacijeAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230218155633_UpdateDb")]
    partial class UpdateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitacija.Services.ProgramLicitacijeAPI.Entities.KreiranjeProgramaLicitacije", b =>
                {
                    b.Property<Guid>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FazaLicitacijeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProgramNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.ToTable("KreiranjeProgramaLicitacije");
                });
#pragma warning restore 612, 618
        }
    }
}
