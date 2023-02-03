﻿// <auto-generated />
using System;
using Licitacija.Services.PredradnjeNadmetanjaAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Migrations
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

            modelBuilder.Entity("Licitacija.Services.PredradnjeNadmetanjaAPI.Entities.PredradnjeNadmetanja", b =>
                {
                    b.Property<Guid>("PredradnjeNadmetanjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PredradnjeNadmetanjaNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PredradnjeNadmetanjaId");

                    b.HasIndex("PredradnjeNadmetanjaNaziv")
                        .IsUnique();

                    b.ToTable("PredradnjeNadmetanja");
                });
#pragma warning restore 612, 618
        }
    }
}
