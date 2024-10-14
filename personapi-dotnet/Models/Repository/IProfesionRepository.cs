using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetProfesionAsync();
        Task<Profesion> GetProfesionByIdAsync(int id);
        Task CreateProfesionAsync(Profesion profesion);
        Task UpdateProfesionAsync(Profesion profesion);
        Task DeleteProfesionAsync(int id);
    }

}
