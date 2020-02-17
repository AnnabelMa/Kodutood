﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sport.Data;

namespace Sport.Migrations
{
    [DbContext(typeof(SpordiContext))]
    partial class SpordiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sport.Models.AsutuseAssignment", b =>
                {
                    b.Property<int>("TreenerID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TreenerID");

                    b.ToTable("AsutuseAssignment");
                });

            modelBuilder.Entity("Sport.Models.Osakond", b =>
                {
                    b.Property<int>("OsakondID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AlgusKP")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Eelarve")
                        .HasColumnType("money");

                    b.Property<string>("Nimi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("TreenerID")
                        .HasColumnType("int");

                    b.HasKey("OsakondID");

                    b.HasIndex("TreenerID");

                    b.ToTable("Osakond");
                });

            modelBuilder.Entity("Sport.Models.Registreering", b =>
                {
                    b.Property<int>("RegistreeringID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpordialaID")
                        .HasColumnType("int");

                    b.Property<int>("SportlaneID")
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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OsakondID")
                        .HasColumnType("int");

                    b.Property<int>("Tulemused")
                        .HasColumnType("int");

                    b.HasKey("SpordialaID");

                    b.HasIndex("OsakondID");

                    b.ToTable("Spordiala");
                });

            modelBuilder.Entity("Sport.Models.SpordialaAssignment", b =>
                {
                    b.Property<int>("SpordialaID")
                        .HasColumnType("int");

                    b.Property<int>("TreenerID")
                        .HasColumnType("int");

                    b.HasKey("SpordialaID", "TreenerID");

                    b.HasIndex("TreenerID");

                    b.ToTable("SpordialaAssignment");
                });

            modelBuilder.Entity("Sport.Models.Sportlane", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eesnimi")
                        .HasColumnName("Eesnimi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Perekonnanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegistreeringuKP")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Sportlane");
                });

            modelBuilder.Entity("Sport.Models.Treener", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eesnimi")
                        .IsRequired()
                        .HasColumnName("Eesnimi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("PalkamiseKP")
                        .HasColumnType("datetime2");

                    b.Property<string>("Perekonnanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Treener");
                });

            modelBuilder.Entity("Sport.Models.AsutuseAssignment", b =>
                {
                    b.HasOne("Sport.Models.Treener", "Treener")
                        .WithOne("AsutuseAssignment")
                        .HasForeignKey("Sport.Models.AsutuseAssignment", "TreenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sport.Models.Osakond", b =>
                {
                    b.HasOne("Sport.Models.Treener", "Administrator")
                        .WithMany()
                        .HasForeignKey("TreenerID");
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
                        .HasForeignKey("SportlaneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sport.Models.Spordiala", b =>
                {
                    b.HasOne("Sport.Models.Osakond", "Osakond")
                        .WithMany("Spordialad")
                        .HasForeignKey("OsakondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sport.Models.SpordialaAssignment", b =>
                {
                    b.HasOne("Sport.Models.Spordiala", "Spordiala")
                        .WithMany("SpordialaAssignments")
                        .HasForeignKey("SpordialaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sport.Models.Treener", "Treener")
                        .WithMany("SpordialaAssignments")
                        .HasForeignKey("TreenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
