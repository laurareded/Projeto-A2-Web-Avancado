using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DracarysAPI.Data;
using DracarysAPI.Models;

namespace DracarysAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DragaoController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public DragaoController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddDragao([FromBody] Dragao dragao)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _appDbContext.Dragoes.Add(dragao);
        await _appDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDragao), new { id = dragao.Id }, dragao);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dragao>>> GetDragoes()
    {
        var dragoes = await _appDbContext.Dragoes.ToListAsync();
        return Ok(dragoes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dragao>> GetDragao(int id)
    {
        var dragao = await _appDbContext.Dragoes.FindAsync(id);

        if (dragao == null)
            return NotFound("Dragão não encontrado!");

        return Ok(dragao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDragao(int id, [FromBody] Dragao dragaoAtualizado)
    {
        var dragaoExistente = await _appDbContext.Dragoes.FindAsync(id);

        if (dragaoExistente == null)
            return NotFound("Dragão não encontrado!");

        _appDbContext.Entry(dragaoExistente).CurrentValues.SetValues(dragaoAtualizado);
        await _appDbContext.SaveChangesAsync();

        return StatusCode(201, dragaoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDragao(int id)
    {
        var dragao = await _appDbContext.Dragoes.FindAsync(id);

        if (dragao == null)
            return NotFound("Dragão não encontrado!");

        _appDbContext.Dragoes.Remove(dragao);
        await _appDbContext.SaveChangesAsync();

        return Ok("Dragão removido com sucesso!");
    }
}
