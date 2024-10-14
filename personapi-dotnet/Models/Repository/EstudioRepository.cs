using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly persona_dbContext _context;

        public EstudioRepository(persona_dbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetEstudiosAsync()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudio> GetEstudioAsync(int idProf, long ccPer)
        {
            return await _context.Estudios.FindAsync(idProf, ccPer);
        }

        public async Task CreateEstudioAsync(Estudio estudio)
        {
            await _context.Estudios.AddAsync(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudioAsync(int idProf, long ccPer)
        {
            var estudio = await GetEstudioAsync(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }
    }


}
