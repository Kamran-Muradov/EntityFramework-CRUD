using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateAsync(Country country);
        Task DeleteAsync(int? id);
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int? id);

    }
}
