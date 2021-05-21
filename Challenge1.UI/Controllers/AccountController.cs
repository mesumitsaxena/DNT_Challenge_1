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
        public IActionResult Edit(int id)
        {
            string userid = id.ToString();
            var user = _authService.GetUser(userid);
            UserModel model = new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CountryName = GetCountryName(user.CountryId),
                CityName = GetCityName(user.CityId),
                CountryId = user.CountryId,
                CityId = user.CityId
            };
            ViewBag.CountryList = _locationService.GetCountries();
            //ViewBag.CityList = _catalogeService.GetItemTypes();
            return View("SignUp",model);

        }
        public IActionResult Delete(int id)
        {
            string userid = id.ToString();
            var user = _authService.GetUser(userid);
            var res = _authService.DeleteUser(user);
            return RedirectToAction("Index");

        }
        private string GetCityName(int Id)
        {
           City city= _locationService.GetCityByid(Id);
            return city.Name;
        }
        private string GetCountryName(int Id)
        {
            Country country = _locationService.GetCountryByid(Id);
            return country.Name;
        }
        public IActionResult Index()
        {
            var users = _authService.GetAllUsers();
            List<UserModel> models = new List<UserModel>();
            foreach(var user in users)
            {
                UserModel model = new UserModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    CountryName=GetCountryName(user.CountryId),
                    CityName=GetCityName(user.CityId),
                    CountryId = user.CountryId,
                    CityId = user.CityId

                };
                models.Add(model);
                
            }
            return View(models);
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
            ModelState.Remove("Id");

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
                    return RedirectToAction("Index","Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.CountryList = _locationService.GetCountries();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            User user = _authService.GetUser(model.Id.ToString());
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("CountryName");
            ModelState.Remove("CityName");
            if (ModelState.IsValid)
            {

                user.Name = model.Name;
                user.UserName = model.Email;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.CountryId = model.CountryId;
                user.CityId = model.CityId;
                
                var result = _authService.UpdateUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.CountryList = _locationService.GetCountries();
            return View("SignUp", model);
        }
    }
}
