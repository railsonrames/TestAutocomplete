using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using TestAutocomplete.Models;
using TestAutocomplete.Services;

namespace TestAutocomplete.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = RestService.For<ICountriesApiService>("https://restcountries.eu/rest/v2");
            var retrivedCountries = await client.GetAllCountriesAsync();

            return View(retrivedCountries);
        }

        public async Task<JsonResult> GetCountriesBySearchValue(string search)
        {
            var client = RestService.For<ICountriesApiService>("https://restcountries.eu/rest/v2");
            var retrivedCountries = await client.GetAllCountriesAsync();
            //var data = retrivedCountries.Find(x => x.Name.Contains(search));
            var data = retrivedCountries.Where(x => x.Name.Contains(search)).Select(x => new Country { Name = x.Name }).ToList();
            return new JsonResult(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
