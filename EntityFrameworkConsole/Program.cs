
using EntityFrameworkConsole.Controllers;
using EntityFrameworkConsole.Data;

#region Classwork

AppDbContext context = new AppDbContext();
void GetAllSettings()
{
    var datas = context.Settings.ToList();

    foreach (var item in datas)
    {
        Console.WriteLine(item.Address + " " + item.Phone + " " + item.Email);
    }
}

void GetById(int id)
{
    var data = context.Settings.FirstOrDefault(m => m.Id == id);

    Console.WriteLine(data.Address + " " + data.Phone + " " + data.Email);

}

//GetAllSettings();

//Console.WriteLine("---------------");

//GetById(2);

SettingController settingController = new SettingController();

//await settingController.GetAllAsync();

//await settingController.GetByIdAsync();

//await settingController.CreateAsync();

//await settingController.DeleteAsync();

//await settingController.GetAllAsync();

CityController cityController = new CityController();

//await cityController.GetAllByCountryIdAsync();

#endregion


#region Homework

CountryController countryController = new CountryController();

//await countryController.CreateAsync();

//await countryController.DeleteAsync();

//await countryController.GetAllAsync();

//await countryController.GetByIdAsync();



//await cityController.CreateAsync();

//await cityController.DeleteAsync();

//await cityController.GetAllAsync();

//await cityController.GetByIdAsync();

#endregion





