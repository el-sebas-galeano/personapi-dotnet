using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoApiController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public TelefonoApiController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: api/Telefono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefonos()
        {
            return await _context.Telefonos.ToListAsync();
        }

        // GET: api/Telefono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefono>> GetTelefono(string id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);

            if (telefono == null)
            {
                return NotFound();
            }

            return telefono;
        }

        // PUT: api/Telefono/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefono(string id, Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return BadRequest();
            }

            _context.Entry(telefono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(id))
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

        // POST: api/Telefono
        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefono", new { id = telefono.Num }, telefono);
        }

        // DELETE: api/Telefono/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefono(string id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonoExists(string id)
        {
            return _context.Telefonos.Any(e => e.Num == id);
        }
    }
}
