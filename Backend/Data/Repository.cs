using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class Repository : IRepository
{
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


    public async Task<Fornecedor[]> GetAllFornecedorAsync(bool includeFornecedor = false)
    {
            IQueryable<Fornecedor> query = _context.Fornecedor;

            query = query.AsNoTracking()
                         .OrderBy(fornecedor => fornecedor.Id);

            return await query.ToArrayAsync();
    }

    public async Task<Fornecedor> GetFornecedorAsyncById(int fornecedorId)
    {
            IQueryable<Fornecedor> query = _context.Fornecedor;

                query = query.AsNoTracking()
                         .OrderBy(fornecedor => fornecedor.Id)
                         .Where(fornecedor => fornecedor.Id == fornecedorId);;

            return await query.FirstOrDefaultAsync();
    }
    
    public async Task<Produto[]> GetAllProdutoAsync(bool includeProduto = false)
    {   
        IQueryable<Produto> query = _context.Produto;

        //if (include){}

        query = query.AsNoTracking()
                    .OrderBy(produto => produto.produtoId);

        return await query.ToArrayAsync();
    }

    public async Task<Produto> GetProdutoAsyncById(int produtoId)
    {
            IQueryable<Produto> query = _context.Produto;

                query = query.AsNoTracking()
                         .OrderBy(produto => produto.codigo)
                         .Where(produto => produto.codigo == produtoId);;

            return await query.FirstOrDefaultAsync();
    }

    public async Task<Pedido[]> GetAllPedidoAsync(bool includePedido = false)
    {
        IQueryable<Pedido> query = _context.Pedido;

        //if (include){}

        query = query.AsNoTracking()
                    .OrderBy(c => c.codigoPedido);

        return await query.ToArrayAsync();
    }

    public async Task<Pedido> GetPedidoAsyncById(int pedidoId)
    {
            IQueryable<Pedido> query = _context.Pedido;

                query = query.AsNoTracking()
                         .OrderBy(pedido => pedido.codigoPedido)
                         .Where(pedido => pedido.codigoPedido == pedidoId);;

            return await query.FirstOrDefaultAsync();
    }

    public async Task<Pedido[]> GetPedidoAsyncByFornecedorId(int fornecedorId, bool includePedido)
    {
        IQueryable<Pedido> query = _context.Pedido;

            query = query.AsNoTracking()
                         .OrderBy(pedido => pedido.codigoPedido)
                    .Where(fornecedor => fornecedor.fornecedorId == fornecedorId);

        return await query.ToArrayAsync();
    }
}