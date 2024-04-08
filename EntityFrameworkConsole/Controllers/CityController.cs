using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
    public class CityController
    {
        private readonly ICityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Enter city name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter country id");
            int countryId = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _cityService.CreateAsync(new City
                {
                    Name = name,
                    CountryId = countryId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add city id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _cityService.DeleteAsync(id);
                Console.WriteLine("Data successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            var datas = await _cityService.GetAllAsync();

            foreach (var item in datas)
            {
                string data = $"Name: {item.Name}, Country: {item.Country.Name}";
                Console.WriteLine(data);
            }
        }

        public async Task GetAllByCountryIdAsync()
        {
            Console.WriteLine("Add country id:");

            int countryId = int.Parse(Console.ReadLine());

            var cities = await _cityService.GetAllByCountryIdAsync(countryId);

            foreach (var item in cities)
            {
                string data = $"Name: {item.Name}, Country: {item.Country.Name}";
                Console.WriteLine(data);
            }
        }

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add city id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _cityService.GetByIdAsync(id);

                string result = $"Name: {data.Name}, Country: {data.Country.Name}";
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
