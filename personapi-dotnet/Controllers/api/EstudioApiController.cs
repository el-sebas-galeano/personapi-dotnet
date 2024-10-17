using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioApiController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public EstudioApiController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: api/Estudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetEstudios()
        {
            return await _context.Estudios.ToListAsync();
        }

        // GET: api/Estudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudio>> GetEstudio(int id)
        {
            var estudio = await _context.Estudios.FindAsync(id);

            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // PUT: api/Estudio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudio(int id, Estudio estudio)
        {
            if (id != estudio.IdProf)
            {
                return BadRequest();
            }

            _context.Entry(estudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(id))
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

        // POST: api/Estudio
        [HttpPost]
        public async Task<ActionResult<Estudio>> PostEstudio(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudio", new { id = estudio.IdProf }, estudio);
        }

        // DELETE: api/Estudio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudio(int id)
        {
            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudioExists(int id)
        {
            return _context.Estudios.Any(e => e.IdProf == id);
        }
    }
}
