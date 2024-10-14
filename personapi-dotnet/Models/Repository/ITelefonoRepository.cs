using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Entities.Repository
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetTelefonosAsync();
        Task<Telefono> GetTelefonoByNumAsync(string num);
        Task CreateTelefonoAsync(Telefono telefono);
        Task UpdateTelefonoAsync(Telefono telefono);
        Task DeleteTelefonoAsync(string num);
    }

}
