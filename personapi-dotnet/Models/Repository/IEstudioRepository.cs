using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public interface IEstudioRepository
    {
        Task<IEnumerable<Estudio>> GetEstudiosAsync();
        Task<Estudio> GetEstudioAsync(int idProf, long ccPer);
        Task CreateEstudioAsync(Estudio estudio);
        Task UpdateEstudioAsync(Estudio estudio);
        Task DeleteEstudioAsync(int idProf, long ccPer);
    }

}
