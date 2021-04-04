﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniNotes_TodoList.Data.Database;

namespace MiniNotes.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("MiniNotes_TodoList.Models.Nota", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conteudo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("MiniNotes_TodoList.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeTag")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NotaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagId");

                    b.HasIndex("NotaId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MiniNotes_TodoList.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("TEXT");

                    b.Property<int>("NotaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MiniNotes_TodoList.Models.Nota", b =>
                {
                    b.HasOne("MiniNotes_TodoList.Models.Usuario", null)
                        .WithMany("Notas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniNotes_TodoList.Models.Tag", b =>
                {
                    b.HasOne("MiniNotes_TodoList.Models.Nota", null)
                        .WithMany("Tags")
                        .HasForeignKey("NotaId");
                });
#pragma warning restore 612, 618
        }
    }
}