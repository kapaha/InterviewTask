using System.Diagnostics;

using Countries.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Countries.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string sortOrder)
    {
        ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

        List<Country> countries = GetCountries();

        switch (sortOrder)
        {
            case "name_desc":
                countries = countries.OrderByDescending(s => s.Name).ToList();
                break;
            default:
                countries = countries.OrderBy(s => s.Name).ToList();
                break;
        }

        return View(countries);
    }

    [Route("Home/Detail/{countryName}")]
    public IActionResult Detail(string countryName)
    {
        Country? country = GetCountryByName(countryName);

        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }

    private Country? GetCountryByName(string name)
    {
        List<Country> countries = GetCountries();

        Country? country = countries.SingleOrDefault(c => c.Name.ToLower() == name.ToLower());

        return country;
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