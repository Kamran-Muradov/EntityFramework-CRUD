using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;

        public CountryService()
        {
            _context = new AppDbContext();
        }

        public async Task CreateAsync(Country country)
        {
            ArgumentNullException.ThrowIfNull(country);

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if(country is null) throw new NotFoundException("Data notfound");

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (country is null) throw new NotFoundException("Data notfound");

            return country;
        }
    }
}
