using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Services.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetByIdAsync(int id);
        Task CreateAsync(Setting setting);
        Task UpdateAsync(Setting setting);
        Task DeleteAsync(int? id);
    }
}
