using CarParkUser.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace CarParkUser.Controllers
{
    public class HomeController : Controller
    {


        //var settings = MongoClient("mongodb+srv://Berkancelik:<password>@cluster0.fkzprct.mongodb.net/?retryWrites=true&w=majority");



        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient client;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, MongoClient client)
        {
            _logger = logger;
            _localizer = localizer;
            client = new MongoClient("mongodb+srv://Berkancelik:Berkan123@cluster0.fkzprct.mongodb.net/?retryWrites=true&w=majority");
        }

        public IActionResult Index()
        {
            var database = client.GetDatabase("CarParkDB");

            var jsonString = System.IO.File.ReadAllText("cities.json");

            var cities = JsonConvert.DeserializeObject<List<cities>>(jsonString);

            var citiesCollection = database.GetCollection<City>("City");
            foreach (var item in cities)
            {
                var city = new City()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = item.name,
                    Plate = item.plate,
                    Latitude = item.latitude,
                    Longitude = item.longtude,
                    Counties = new List<County>()
                };
                foreach (var item2 in item.counties)
                {
                    city.Counties.Add(new County
                    {
                        Id = ObjectId.GenerateNewId(),
                        Name = item2,
                        Latitude = "",
                        Longitude = "",
                        PostCode= ""

                    });
                }
                citiesCollection.InsertOne(city);
            }


            return View();
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
