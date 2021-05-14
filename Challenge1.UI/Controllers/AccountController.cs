using Challenge1.Entities;
using Challenge1.Services.Interfaces;
using Challenge1.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge1.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authService;
        ILocationService _locationService;
        public AccountController(IAuthenticationService authService, ILocationService locationService)
        {
            
            
             _authService = authService;
            _locationService = locationService;
        }
        public IActionResult SignUp()
        {
            ViewBag.CountryList = _locationService.GetCountries();
            //ViewBag.CityList = _catalogeService.GetItemTypes();
            return View();

        }
        public JsonResult GetCities(int CountryId)
        {
            IEnumerable<City> city = new List<City>();
            city = _locationService.GetCitiesBasedonCountry(CountryId);
            return Json(new SelectList(city, "Id", "Name"));
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });

                    }

                }
                else
                {
                    ModelState.AddModelError("", "User/Password is Incorrect!!");
                }
            }
            ViewBag.CountryList = _locationService.GetCountries();
            return View();

        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    CountryId=model.CountryId,
                    CityId=model.CityId
                };
                var result = _authService.CreateUser(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.CountryList = _locationService.GetCountries();
            return View();
        }
    }
}
