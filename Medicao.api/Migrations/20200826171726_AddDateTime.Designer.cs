﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaMedicao;

namespace Medição.Migrations
{
    [DbContext(typeof(MedicaoDbContext))]
    [Migration("20200826171726_AddDateTime")]
    partial class AddDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaMedicao.Models.Medicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtMedicao")
                        .HasColumnType("dateTime");

                    b.Property<double>("Temperatura")
                        .HasColumnType("float");

                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pessoaId");

                    b.ToTable("Medicoes");
                });

            modelBuilder.Entity("SistemaMedicao.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("setorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("setorId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("SistemaMedicao.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("SistemaMedicao.Models.Medicao", b =>
                {
                    b.HasOne("SistemaMedicao.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaMedicao.Models.Pessoa", b =>
                {
                    b.HasOne("SistemaMedicao.Models.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("setorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
