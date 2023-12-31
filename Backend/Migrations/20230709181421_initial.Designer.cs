﻿// <auto-generated />
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230709181421_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Backend.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("contato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nomeContato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("razaoSocial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            cnpj = "1200005555555555",
                            contato = "33888888888",
                            email = "helio@gmail",
                            nomeContato = "Helio",
                            razaoSocial = "Pre Moldados Janauba",
                            uf = "MG"
                        },
                        new
                        {
                            Id = 2,
                            cnpj = "88888555555555555",
                            contato = "885555555555",
                            email = "maicon@gmail",
                            nomeContato = "Maicon",
                            razaoSocial = "MagnoOn Digital",
                            uf = "MG"
                        });
                });

            modelBuilder.Entity("Backend.Models.FornecedorPedido", b =>
                {
                    b.Property<int>("fornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pedidoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("fornecedorId", "pedidoId");

                    b.HasIndex("pedidoId");

                    b.ToTable("FornecedorPedido");

                    b.HasData(
                        new
                        {
                            fornecedorId = 1,
                            pedidoId = 1
                        },
                        new
                        {
                            fornecedorId = 1,
                            pedidoId = 3
                        },
                        new
                        {
                            fornecedorId = 1,
                            pedidoId = 5
                        },
                        new
                        {
                            fornecedorId = 2,
                            pedidoId = 2
                        },
                        new
                        {
                            fornecedorId = 2,
                            pedidoId = 4
                        },
                        new
                        {
                            fornecedorId = 2,
                            pedidoId = 6
                        });
                });

            modelBuilder.Entity("Backend.Models.Pedido", b =>
                {
                    b.Property<int>("codigoPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataPedido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("fornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("produtoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantidadeProdutos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("valorTotalPedido")
                        .HasColumnType("INTEGER");

                    b.HasKey("codigoPedido");

                    b.ToTable("Pedido");

                    b.HasData(
                        new
                        {
                            codigoPedido = 1,
                            dataPedido = "08/07/2023",
                            fornecedorId = 1,
                            produtoId = 1,
                            quantidadeProdutos = 5000,
                            valorTotalPedido = 15000
                        },
                        new
                        {
                            codigoPedido = 2,
                            dataPedido = "08/07/2023",
                            fornecedorId = 2,
                            produtoId = 2,
                            quantidadeProdutos = 50,
                            valorTotalPedido = 15000
                        },
                        new
                        {
                            codigoPedido = 3,
                            dataPedido = "08/07/2023",
                            fornecedorId = 1,
                            produtoId = 1,
                            quantidadeProdutos = 1000,
                            valorTotalPedido = 3000
                        },
                        new
                        {
                            codigoPedido = 4,
                            dataPedido = "08/07/2023",
                            fornecedorId = 2,
                            produtoId = 2,
                            quantidadeProdutos = 30,
                            valorTotalPedido = 9000
                        },
                        new
                        {
                            codigoPedido = 5,
                            dataPedido = "08/07/2023",
                            fornecedorId = 1,
                            produtoId = 1,
                            quantidadeProdutos = 10000,
                            valorTotalPedido = 30000
                        },
                        new
                        {
                            codigoPedido = 6,
                            dataPedido = "08/07/2023",
                            fornecedorId = 2,
                            produtoId = 2,
                            quantidadeProdutos = 10,
                            valorTotalPedido = 3000
                        });
                });

            modelBuilder.Entity("Backend.Models.Produto", b =>
                {
                    b.Property<int>("produtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("codigo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataCadastro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("valorProduto")
                        .HasColumnType("INTEGER");

                    b.HasKey("produtoId");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            produtoId = 1,
                            codigo = 5,
                            dataCadastro = "01/04/2023",
                            descricao = "blocos",
                            valorProduto = 3
                        },
                        new
                        {
                            produtoId = 2,
                            codigo = 10,
                            dataCadastro = "30/09/2022",
                            descricao = "artes digitais",
                            valorProduto = 300
                        });
                });

            modelBuilder.Entity("Backend.Models.FornecedorPedido", b =>
                {
                    b.HasOne("Backend.Models.Fornecedor", "fornecedor")
                        .WithMany()
                        .HasForeignKey("fornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fornecedor");

                    b.Navigation("pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
