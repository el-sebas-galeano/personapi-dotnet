using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonaRepository : IPersonaRepository
    {
        private readonly persona_dbContext _context;

        public PersonaRepository(persona_dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.Include(p => p.Estudios).Include(p => p.Telefonos);
        }

        public Persona GetPersonaByCc(long cc)
        {
            return _context.Personas
                           .Include(p => p.Estudios)
                           .Include(p => p.Telefonos)
                           .FirstOrDefault(p => p.Cc == cc);
        }

        public async Task CreatePersonaAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonaAsync(long cc)
        {
            var persona = await _context.Personas.FindAsync(cc);
            if (persona == null)
            {
                return; 
            }
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

    }

}
