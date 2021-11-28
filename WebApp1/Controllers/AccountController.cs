using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Account has been created successfully";
                TempData["Name"] = model.Name;
                string strUser = JsonSerializer.Serialize(model);
                HttpContext.Session.SetString("User", strUser);
                //HttpContext.Session.SetString("Email", model.Email);

                Response.Cookies.Append("non-persisten", "My non-persistent cookie");
                Response.Cookies.Append("non-persisten", "My non-persistent cookie", new CookieOptions { Expires = DateTime.Now.AddDays(7) });
                return RedirectToAction("DashBoard");
            }
            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        List<Country> countrylist = new List<Country>()
        {
            new Country(){CountryID = 1,CountryName = "USA" },
            new Country(){CountryID = 2,CountryName = "India" },
        };

        List<City> cityList = new List<City>()
        {
            new City() { CityID = 1, CityName = "New York", CountryID = 1 },
            new City() { CityID = 2, CityName = "Washington", CountryID = 1 },
            new City() { CityID = 3, CityName = "Chicago", CountryID = 1 },
            new City() { CityID = 4, CityName = "Hyderabad", CountryID = 2 },
            new City() { CityID = 5, CityName = "Chennai", CountryID = 2 },

        };

        public JsonResult GetCountries()
        {
            return Json(countrylist);
        }

        public JsonResult GetCities(int CID)
        {
            var cities = cityList.Where(p => p.CountryID == CID);
            return Json(cities);
        }
    }
}
