using GerenciamentoEstudantes.Data;
using GerenciamentoEstudantes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstudantes.Controllers;

[ApiController]
[Route("/alunos")]
public class AlunosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AlunosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlunos()
    {
        var alunos = await _context.Alunos.ToListAsync();
        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAluno(Guid id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno == null)
        {
            return NotFound();
        }

        return Ok(aluno);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAluno(Guid id, Aluno aluno)
    {
        if (id != aluno.Id)
        {
            return BadRequest();
        }

        _context.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAluno(Guid id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlunoExists(Guid id)
    {
        return _context.Alunos.Any(e => e.Id == id);
    }
}
