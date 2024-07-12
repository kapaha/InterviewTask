using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Countries.Models;
using Newtonsoft.Json;

namespace Countries.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        List<Country> countries = GetCountries();

        return View(countries);
    }

    private List<Country> GetCountries()
    {
        string filePath = "/Users/kaiz/interview/InterviewTask/src/Countries/Data/countries.json";

        string jsonContent = System.IO.File.ReadAllText(filePath);

        CountryData countryData = JsonConvert.DeserializeObject<CountryData>(jsonContent);

        List<Country> countries = countryData.Countries;

        return countries;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
