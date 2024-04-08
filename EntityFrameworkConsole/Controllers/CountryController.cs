using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
    public class CountryController
    {
        private readonly ICountryService _countryService;

        public CountryController()
        {
            _countryService = new CountryService();
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Enter country name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter population");
            int population = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _countryService.CreateAsync(new Country
                {
                    Name = name,
                    Population = population
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add country id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _countryService.DeleteAsync(id);
                Console.WriteLine("Data successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            var datas = await _countryService.GetAllAsync();

            foreach (var item in datas)
            {
                string result = $"Name: {item.Name}, Population: {item.Population}";
                Console.WriteLine(result);
            }
        }

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add country id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _countryService.GetByIdAsync(id);

                string result =  $"Name: {data.Name}, Population: {data.Population}";
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
