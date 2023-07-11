using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<FornecedorPedido> FornecedorPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FornecedorPedido>()
                .HasKey(AD => new { AD.fornecedorId, AD.pedidoId });

            builder.Entity<Pedido>()
                .HasKey(AD => new { AD.codigoPedido });

            builder.Entity<Fornecedor>()
                .HasData(new List<Fornecedor>(){
                    new Fornecedor(id: 1, razaoSocial:"Pre Moldados Janauba", cnpj:"1200005555555555", uf:"MG", email:"helio@gmail", contato:"33888888888", nomeContato:"Helio"),
                    new Fornecedor(id: 2, razaoSocial:"MagnoOn Digital", cnpj:"88888555555555555", uf:"MG", email:"maicon@gmail", contato:"885555555555", nomeContato:"Maicon"),

                });
            
            builder.Entity<Produto>()
                .HasData(new List<Produto>{
                    new Produto(produtoId: 1, codigo: 5, descricao:"blocos", dataCadastro:"01/04/2023", valorProduto: 3),
                    new Produto(produtoId: 2,codigo: 10, descricao:"artes digitais", dataCadastro:"30/09/2022", valorProduto:300 ),

                });
            
            builder.Entity<Pedido>()
                .HasData(new List<Pedido>(){
                    new Pedido(codigoPedido: 1, produtoid: 1, dataPedido:"08/07/2023", quantidadeProdutos: 5000, fornecedorId : 1, valorTotalPedido: 15000),
                    new Pedido(codigoPedido: 2, produtoid: 2, dataPedido:"08/07/2023", quantidadeProdutos: 50,fornecedorId : 2, valorTotalPedido: 15000),
                    new Pedido(codigoPedido: 3, produtoid: 1, dataPedido:"08/07/2023", quantidadeProdutos: 1000,fornecedorId : 1, valorTotalPedido: 3000),
                    new Pedido(codigoPedido: 4, produtoid: 2, dataPedido:"08/07/2023", quantidadeProdutos: 30,fornecedorId : 2, valorTotalPedido: 9000),
                    new Pedido(codigoPedido: 5, produtoid: 1, dataPedido:"08/07/2023", quantidadeProdutos: 10000,fornecedorId : 1, valorTotalPedido: 30000),
                    new Pedido(codigoPedido: 6, produtoid: 2, dataPedido:"08/07/2023", quantidadeProdutos: 10,fornecedorId : 2, valorTotalPedido: 3000)
                });

            builder.Entity<FornecedorPedido>()
                .HasData(new List<FornecedorPedido>() {
                    new FornecedorPedido() {fornecedorId = 1, pedidoId = 1 },
                    new FornecedorPedido() {fornecedorId = 1, pedidoId = 3 },
                    new FornecedorPedido() {fornecedorId = 1, pedidoId = 5 },
                    new FornecedorPedido() {fornecedorId = 2, pedidoId = 2 },
                    new FornecedorPedido() {fornecedorId = 2, pedidoId = 4 },
                    new FornecedorPedido() {fornecedorId = 2, pedidoId = 6 }
                });
        }

}