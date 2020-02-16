﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sport.Data;

namespace Sport.Migrations
{
    [DbContext(typeof(SpordiContext))]
    [Migration("20200216101026_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sport.Models.Registreering", b =>
                {
                    b.Property<int>("RegistreeringID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpordialaID")
                        .HasColumnType("int");

                    b.Property<int?>("SportlaneID")
                        .HasColumnType("int");

                    b.Property<int>("SportlaseID")
                        .HasColumnType("int");

                    b.HasKey("RegistreeringID");

                    b.HasIndex("SpordialaID");

                    b.HasIndex("SportlaneID");

                    b.ToTable("Registreering");
                });

            modelBuilder.Entity("Sport.Models.Spordiala", b =>
                {
                    b.Property<int>("SpordialaID")
                        .HasColumnType("int");

                    b.Property<string>("Nimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tulemused")
                        .HasColumnType("int");

                    b.HasKey("SpordialaID");

                    b.ToTable("Spordiala");
                });

            modelBuilder.Entity("Sport.Models.Sportlane", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eesnimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perekonnanimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistreeringuKP")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Sportlane");
                });

            modelBuilder.Entity("Sport.Models.Registreering", b =>
                {
                    b.HasOne("Sport.Models.Spordiala", "Spordiala")
                        .WithMany("Registreeringud")
                        .HasForeignKey("SpordialaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sport.Models.Sportlane", "Sportlane")
                        .WithMany("Registreeringud")
                        .HasForeignKey("SportlaneID");
                });
#pragma warning restore 612, 618
        }
    }
}
