using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Services.Interfaces
{
    public interface ICityService
    {
        Task CreateAsync(City city);
        Task DeleteAsync(int? id);
        Task<List<City>> GetAllAsync();
        Task<List<City>> GetAllByCountryIdAsync(int id);
        Task<City> GetByIdAsync(int? id);
    }
}
