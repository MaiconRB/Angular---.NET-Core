namespace Backend.Models;

public class FornecedorPedido
{
    public FornecedorPedido(){ }
    public FornecedorPedido(int fornecedorId, int pedidoId)
    {
        //this.fornecedor = fornecedor;
        this.fornecedorId = fornecedorId;
        //this.pedido = pedido;
        this.pedidoId = pedidoId;
    }

    public Fornecedor fornecedor { get; set; }

    public int fornecedorId { get; set; }

    public Pedido pedido { get; set; }

    public int pedidoId { get; set; }


}