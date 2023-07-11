using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly IRepository _repo;
    public FornecedorController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result =  await _repo.GetAllFornecedorAsync(true);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest ($"Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Fornecedor model)
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

    [HttpPut("{fornecedorId}")]
    public async Task<IActionResult> Put(int fornecedorId, Fornecedor model)
    {
        try
        {
            var fornecedor = await _repo.GetFornecedorAsyncById(fornecedorId);
            if(fornecedor == null)return NotFound();

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

    [HttpDelete("{fornecedorId}")]
    public async Task<IActionResult> Delete(int fornecedorId)
    {
        try
        {
            var fornecedor = await _repo.GetFornecedorAsyncById(fornecedorId);
            if(fornecedor == null)return NotFound();

            _repo.Delete(fornecedor);

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
