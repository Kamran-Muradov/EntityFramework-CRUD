using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;

        public SettingService()
        {
            _context = new AppDbContext();
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            var data = await _context.Settings.FirstOrDefaultAsync(m => m.Id == id);

            if (data is null) throw new NotFoundException("Data notfound");

            return data;
        }

        public async Task CreateAsync(Setting setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Setting setting)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var data = await _context.Settings.FirstOrDefaultAsync(m => m.Id == id);

            if (data is null) throw new NotFoundException("Data notfound");

            _context.Settings.Remove(data);

            await _context.SaveChangesAsync();
        }
    }
}
