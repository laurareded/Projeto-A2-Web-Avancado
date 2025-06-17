using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DracarysAPI.Data;
using DracarysAPI.Models;

namespace DracarysAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonagemController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public PersonagemController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _appDbContext.Personagens.Add(personagem);
        await _appDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPersonagem), new { id = personagem.Id }, personagem);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
    {
        var personagens = await _appDbContext.Personagens.ToListAsync();
        return Ok(personagens);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Personagem>> GetPersonagem(int id)
    {
        var personagem = await _appDbContext.Personagens.FindAsync(id);

        if (personagem == null)
            return NotFound("Personagem não encontrado!");

        return Ok(personagem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
    {
        var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

        if (personagemExistente == null)
            return NotFound("Personagem não encontrado!");

        _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);
        await _appDbContext.SaveChangesAsync();

        return StatusCode(201, personagemAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonagem(int id)
    {
        var personagem = await _appDbContext.Personagens.FindAsync(id);

        if (personagem == null)
            return NotFound("Personagem não encontrado!");

        _appDbContext.Personagens.Remove(personagem);
        await _appDbContext.SaveChangesAsync();

        return Ok("Personagem removido com sucesso!");
    }
}
