using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {

        
        List<CityWeather> cities = new List<CityWeather>() {
        new CityWeather() {
            CityUniqueCode = "LDN",
            CityName = "London",
            DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
            TemperatureFahrenheit = 33 },

        new CityWeather() {
            CityUniqueCode = "NYC",
            CityName = "New York",
            DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
            TemperatureFahrenheit = 60 },

        new CityWeather() {
            CityUniqueCode = "PAR",
            CityName = "Paris",
            DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
            TemperatureFahrenheit = 82 }
        };

        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Weather App - Home Page";
            Response.StatusCode = 200; //OK
            return View("Index", cities);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult CityView(string? cityCode)
        {
            if (cityCode != null)
            {
                foreach (CityWeather city in cities)
                {
                    if (city.CityUniqueCode == cityCode)
                    {
                        ViewData["Title"] = $"Weather App - {city.CityName}";
                        Response.StatusCode = 200; // OK
                        return View("CityView", city);
                    }
                }

                // If no matching city is found
                ViewData["Title"] = "Weather App - City Not Found";
                Response.StatusCode = 404; // Not Found
                return View("Error");
            }

            // If cityCode is null
            ViewData["Title"] = "Weather App - Invalid Request";
            Response.StatusCode = 400; // Bad Request
            return View("Error");
        }

    }
}
