using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetPersonas();
        Persona GetPersonaByCc(long cc);
        Task CreatePersonaAsync(Persona persona);
        Task UpdatePersonaAsync(Persona persona);
        Task DeletePersonaAsync(long cc);
    }

}
