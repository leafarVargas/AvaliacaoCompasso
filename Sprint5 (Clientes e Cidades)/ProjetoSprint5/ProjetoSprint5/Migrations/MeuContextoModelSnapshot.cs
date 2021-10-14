﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoSprint5.Dados;

namespace ProjetoSprint5.Migrations
{
    [DbContext(typeof(MeuContexto))]
    partial class MeuContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ProjetoSprint5.Modelos.Cidade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ProjetoSprint5.Modelos.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .HasColumnType("text");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cidadeID")
                        .HasColumnType("int");

                    b.Property<string>("datanascimento")
                        .HasColumnType("text");

                    b.Property<string>("localidade")
                        .HasColumnType("text");

                    b.Property<string>("logradouro")
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("uf")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
