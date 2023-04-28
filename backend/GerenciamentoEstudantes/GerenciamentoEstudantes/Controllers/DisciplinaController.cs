using GerenciamentoEstudantes.Data;
using GerenciamentoEstudantes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstudantes.Controllers
{

    [ApiController]
    [Route("/disciplinas")]
    public class DisciplinaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DisciplinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> GetDisciplinas()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> GetDisciplina(Guid id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return disciplina;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplina(Guid id, Disciplina disciplina)
        {
            if (id != disciplina.Id)
            {
                return BadRequest();
            }

            _context.Entry(disciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Disciplina>> PostDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDisciplina), new { id = disciplina.Id }, disciplina);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplina(Guid id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplinaExists(Guid id)
        {
            return _context.Disciplinas.Any(e => e.Id == id);
        }
    }
}
