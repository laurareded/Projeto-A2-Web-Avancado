using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DracarysAPI.Data;
using DracarysAPI.Models;

namespace DracarysAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CasaController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CasaController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddCasa([FromBody] Casa casa)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _appDbContext.Casas.Add(casa);
        await _appDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCasa), new { id = casa.Id }, casa);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Casa>>> GetCasas()
    {
        var casas = await _appDbContext.Casas.ToListAsync();
        return Ok(casas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Casa>> GetCasa(int id)
    {
        var casa = await _appDbContext.Casas.FindAsync(id);

        if (casa == null)
            return NotFound("Casa não encontrada!");

        return Ok(casa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCasa(int id, [FromBody] Casa casaAtualizada)
    {
        var casaExistente = await _appDbContext.Casas.FindAsync(id);

        if (casaExistente == null)
            return NotFound("Casa não encontrada!");

        _appDbContext.Entry(casaExistente).CurrentValues.SetValues(casaAtualizada);
        await _appDbContext.SaveChangesAsync();

        return StatusCode(201, casaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCasa(int id)
    {
        var casa = await _appDbContext.Casas.FindAsync(id);

        if (casa == null)
            return NotFound("Casa não encontrada!");

        _appDbContext.Casas.Remove(casa);
        await _appDbContext.SaveChangesAsync();

        return Ok("Casa deletada com sucesso!");
    }
}