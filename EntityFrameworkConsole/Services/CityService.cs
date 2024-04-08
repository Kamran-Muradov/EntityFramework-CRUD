using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Services
{
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;

        public CityService()
        {
            _context = new AppDbContext();
        }

        public async Task CreateAsync(City city)
        {
            ArgumentNullException.ThrowIfNull(city);

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);

            if (city is null) throw new NotFoundException("Data notfound");

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities.Include(m => m.Country).ToListAsync();
        }

        public async Task<List<City>> GetAllByCountryIdAsync(int id)
        {
            return await _context.Cities.Include(m => m.Country).Where(m => m.CountryId == id).ToListAsync();
        }

        public async Task<City> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var city = await _context.Cities.Include(m=>m.Country).FirstOrDefaultAsync(m => m.Id == id);

            if (city is null) throw new NotFoundException("Data notfound");

            return city;
        }
    }
}
