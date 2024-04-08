using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
    public class SettingController
    {
        private readonly ISettingService _settingService;

        public SettingController()
        {
            _settingService = new SettingService();
        }

        public async Task GetAllAsync()
        {
            var datas = await _settingService.GetAllAsync();

            foreach (var item in datas)
            {
                string data = $"Name: {item.Name}, Email: {item.Email}, Phone: {item.Phone}, Address: {item.Address}";
                Console.WriteLine(data);
            }
        }

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add setting id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _settingService.GetByIdAsync(id);

                string result = $"Name: {data.Name}, Email:{data.Email}, Phone: {data.Phone}, Address:{data.Address}";
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Add name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add address:");
            string address = Console.ReadLine();

            Console.WriteLine("Add email:");
            string email = Console.ReadLine();

            Console.WriteLine("Add phone:");
            string phone = Console.ReadLine();

            await _settingService.CreateAsync(new Setting
            {
                Name = name,
                Address = address,
                Email = email,
                Phone = phone
            });
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add setting id:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _settingService.DeleteAsync(id);
                Console.WriteLine("Data deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
