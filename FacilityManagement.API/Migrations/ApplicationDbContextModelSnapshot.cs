﻿// <auto-generated />
using System;
using FacilityManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FacilityManagement.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FacilityManagement.API.Models.Compressor", b =>
                {
                    b.Property<int>("CompressorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.HasKey("CompressorId");

                    b.ToTable("Compressors");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.CompressorSubType", b =>
                {
                    b.Property<int>("CompressorSubTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompressorId");

                    b.Property<string>("Name");

                    b.HasKey("CompressorSubTypeId");

                    b.HasIndex("CompressorId");

                    b.ToTable("CompressorSubTypes");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.CompressorSystem", b =>
                {
                    b.Property<int>("CompressorSystemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompressorSubTypeId");

                    b.Property<string>("Name");

                    b.HasKey("CompressorSystemId");

                    b.HasIndex("CompressorSubTypeId");

                    b.ToTable("CompressorSystems");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompressorSystemId");

                    b.Property<string>("Name");

                    b.HasKey("PartId");

                    b.HasIndex("CompressorSystemId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.CompressorSubType", b =>
                {
                    b.HasOne("FacilityManagement.API.Models.Compressor", "Compressor")
                        .WithMany()
                        .HasForeignKey("CompressorId");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.CompressorSystem", b =>
                {
                    b.HasOne("FacilityManagement.API.Models.CompressorSubType", "CompressorSubType")
                        .WithMany("CompressorSystems")
                        .HasForeignKey("CompressorSubTypeId");
                });

            modelBuilder.Entity("FacilityManagement.API.Models.Part", b =>
                {
                    b.HasOne("FacilityManagement.API.Models.CompressorSystem", "CompressorSystem")
                        .WithMany("Parts")
                        .HasForeignKey("CompressorSystemId");
                });
#pragma warning restore 612, 618
        }
    }
}
