﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResTIConnect.Infrastructure;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    [DbContext(typeof(OrdemDeServicoContext))]
    partial class OrdemDeServicoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CretedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<int>("Ordem_De_ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("longtext");

                    b.Property<int>("Prestador_De_ServicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("Ordem_De_ServicoId")
                        .IsUnique();

                    b.HasIndex("Prestador_De_ServicoId")
                        .IsUnique();

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Ordem_De_Servico", b =>
                {
                    b.Property<int>("Ordem_De_ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CretedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Ordem_De_ServicoId");

                    b.ToTable("Ordem_De_Servicos", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Prestador_De_Servico", b =>
                {
                    b.Property<int>("Prestador_De_ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CretedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Prestador_De_ServicoId");

                    b.ToTable("Prestador_De_Servicos", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Servico_Ordem_De_Servico", b =>
                {
                    b.Property<int>("Servico_Ordem_De_ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CretedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("Ordem_De_ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Servico_Ordem_De_ServicoId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Servico_Ordem_De_Servicos", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Ordem_De_Servico", "Ordem_De_Servico")
                        .WithOne("Endereco")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.Endereco", "Ordem_De_ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrdemDeServico.Domain.Entities.Prestador_De_Servico", "Prestador_De_Servico")
                        .WithOne("Endereco")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.Endereco", "Prestador_De_ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ordem_De_Servico");

                    b.Navigation("Prestador_De_Servico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Servico_Ordem_De_Servico", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Servico_Ordem_De_Servico")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.Servico_Ordem_De_Servico", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Servico_Ordem_De_Servico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Ordem_De_Servico", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Prestador_De_Servico", b =>
                {
                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
