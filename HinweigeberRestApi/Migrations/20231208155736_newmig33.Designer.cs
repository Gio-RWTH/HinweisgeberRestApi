﻿// <auto-generated />
using System;
using HinweigeberRestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HinweigeberRestApi.Migrations
{
    [DbContext(typeof(HinweisDbContext))]
    [Migration("20231208155736_newmig33")]
    partial class newmig33
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HinweigeberRestApi.Data.Massnahme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Massnahmes");
                });

            modelBuilder.Entity("HinweigeberRestApi.Data.Meldung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<bool>("isFinished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Meldungs");
                });

            modelBuilder.Entity("HinweigeberRestApi.Data.Weitereinfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MassnahmeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MassnahmeId")
                        .IsUnique();

                    b.ToTable("WeitereInfo");
                });

            modelBuilder.Entity("MassnahmeMeldung", b =>
                {
                    b.Property<int>("MassnahmenId")
                        .HasColumnType("int");

                    b.Property<int>("MeldungenId")
                        .HasColumnType("int");

                    b.HasKey("MassnahmenId", "MeldungenId");

                    b.HasIndex("MeldungenId");

                    b.ToTable("MassnahmeMeldung");
                });

            modelBuilder.Entity("HinweigeberRestApi.Data.Weitereinfo", b =>
                {
                    b.HasOne("HinweigeberRestApi.Data.Massnahme", "Massnahme")
                        .WithOne("WeitereInfo")
                        .HasForeignKey("HinweigeberRestApi.Data.Weitereinfo", "MassnahmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Massnahme");
                });

            modelBuilder.Entity("MassnahmeMeldung", b =>
                {
                    b.HasOne("HinweigeberRestApi.Data.Massnahme", null)
                        .WithMany()
                        .HasForeignKey("MassnahmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HinweigeberRestApi.Data.Meldung", null)
                        .WithMany()
                        .HasForeignKey("MeldungenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HinweigeberRestApi.Data.Massnahme", b =>
                {
                    b.Navigation("WeitereInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
