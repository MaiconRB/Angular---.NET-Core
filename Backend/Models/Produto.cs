namespace Backend.Models;

public class Produto
{
    public Produto(){}
    public Produto(int produtoId, int codigo, string descricao, string dataCadastro, int valorProduto)
    {
        this.produtoId = produtoId;
        this.codigo = codigo;
        this.descricao = descricao;
        this.dataCadastro = dataCadastro;
        this.valorProduto = valorProduto;
    }

    public int produtoId { get; set; }
    public int codigo { get; set; }
    public string descricao { get; set; }
    public string dataCadastro { get; set; } //verificar tipo
    public int valorProduto { get; set; } //verificar tipo

}