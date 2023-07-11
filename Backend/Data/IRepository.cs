
using Backend.Models;

namespace Backend.Data;

public interface IRepository
{
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Fornecedor
        Task<Fornecedor[]> GetAllFornecedorAsync(bool includeFornecedor);        
        Task<Fornecedor> GetFornecedorAsyncById(int fornecedorId);
        
        //Produto
        Task<Produto[]> GetAllProdutoAsync(bool includeProduto);
        Task<Produto> GetProdutoAsyncById(int produtoId);

        //Pedido
        Task<Pedido[]> GetAllPedidoAsync(bool includePedido);
        Task<Pedido> GetPedidoAsyncById(int pedidoId);
        Task<Pedido[]> GetPedidoAsyncByFornecedorId(int fornecedorId, bool includePedido);

}