using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly persona_dbContext _context;

        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetProfesionAsync()
        {
            return await _context.Profesions.ToListAsync();
        }

        public async Task<Profesion> GetProfesionByIdAsync(int id)
        {
            return await _context.Profesions.FindAsync(id);
        }

        public async Task CreateProfesionAsync(Profesion profesion)
        {
            await _context.Profesions.AddAsync(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesionAsync(int id)
        {
            var profesion = await GetProfesionByIdAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }
    }

}

