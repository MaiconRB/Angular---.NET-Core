namespace Backend.Models;

public class Pedido
{
    public Pedido(){}
    public Pedido(int codigoPedido, string dataPedido, int produtoid, int quantidadeProdutos, int fornecedorId, int valorTotalPedido)
    {
        this.codigoPedido = codigoPedido;
        this.dataPedido = dataPedido;
        this.produtoId = produtoid;
        this.quantidadeProdutos = quantidadeProdutos;
        this.fornecedorId = fornecedorId;
        this.valorTotalPedido = valorTotalPedido;
    }

    public int codigoPedido { get; set; }
    public string dataPedido { get; set; } //verificar tipo
    //public string produto { get; set; }
    public int produtoId { get; set; }
    public int quantidadeProdutos { get; set; } 
    //public string fornecedor { get; set; }
    public int fornecedorId { get; set; }
    public int valorTotalPedido { get; set; } //verificar tipo
    
}