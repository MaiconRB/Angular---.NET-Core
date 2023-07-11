using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IRepository _repo;
    public PedidoController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result =  await _repo.GetAllPedidoAsync(true);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }
    }

    [HttpGet("ByFornecedor/{fornecedorId}")]
    public async Task<IActionResult> GetbyFornecedorId(int fornecedorId)
    {
        try
        {
            var result =  await _repo.GetPedidoAsyncByFornecedorId(fornecedorId, true);
            
            
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pedido model)
    {
        try
        {
            _repo.Add(model);

            if(await _repo.SaveChangesAsync())
            {
                return Ok(model);
            }
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }

        return BadRequest ();
    }

    [HttpPut("{pedidoId}")]
    public async Task<IActionResult> Put(int pedidoId, Pedido model)
    {
        try
        {
            var pedido = await _repo.GetPedidoAsyncById(pedidoId);
            if(pedido == null)return NotFound();

            _repo.Update(model);

            if(await _repo.SaveChangesAsync())
            {
                return Ok(model);
            }
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }

        return BadRequest ();
    }

    [HttpDelete("{pedidoId}")]
    public async Task<IActionResult> Delete(int pedidoId)
    {
        try
        {
            var pedido = await _repo.GetPedidoAsyncById(pedidoId);
            if(pedido == null)return NotFound();

            _repo.Delete(pedido);

            if(await _repo.SaveChangesAsync())
            {
                return Ok(new { message = "Deletado"});
            }
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }

        return BadRequest ();
    }
}