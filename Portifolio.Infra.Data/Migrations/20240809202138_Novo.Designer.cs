﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portifolio.Infra.Data.Context;

#nullable disable

namespace Portifolio.Infra.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240809202138_Novo")]
    partial class Novo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Portifolio.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Projeto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pessoaId");

                    b.ToTable("projeto");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("login")
                        .IsUnique();

                    b.HasIndex("pessoaId")
                        .IsUnique();

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Projeto", b =>
                {
                    b.HasOne("Portifolio.Domain.Entities.Pessoa", "pessoa")
                        .WithMany("projetos")
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Portifolio.Domain.Entities.Pessoa", "pessoa")
                        .WithOne("usuario")
                        .HasForeignKey("Portifolio.Domain.Entities.Usuario", "pessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("projetos");

                    b.Navigation("usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
