namespace Backend.Models;

public class Fornecedor
{
    public Fornecedor(){ }
    public Fornecedor(int id, string razaoSocial, string cnpj, string uf, string email, string contato, string nomeContato)
    {
        this.Id = id;
        this.razaoSocial = razaoSocial;
        this.cnpj = cnpj;
        this.uf = uf;
        this.email = email;
        this.contato = contato;
        this.nomeContato = nomeContato;
    }

    public int Id { get; set; }
    public string razaoSocial { get; set; }
    public string cnpj { get; set; }
    public string uf { get; set; }
    public string email { get; set; }
    public string contato { get; set; }
    public string nomeContato { get; set; }

}