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
    [Migration("20240813145323_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Portifolio.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varbinary(255)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varbinary(255)");

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
