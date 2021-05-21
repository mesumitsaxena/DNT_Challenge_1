using Challenge1.Entities;
using Challenge1.Repository.Interfaces;
using Challenge1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Services.Implementation
{
    public class LocationService:ILocationService
    {
        private readonly IRepository<Country> _countryRepo;
        private readonly IRepository<City> _cityRepo;

        public LocationService(IRepository<Country> countryRepo, IRepository<City> cityRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
        }

        public IEnumerable<City> GetCitiesBasedonCountry(int CountryId)
        {
            return _cityRepo.GetAll().Where(c=>c.CountryId==CountryId).ToList();
        }

        public City GetCityByid(int Id)
        {
            return _cityRepo.Find(Id);
        }

        public IEnumerable<Country> GetCountries()
        {
            return _countryRepo.GetAll();
        }

        public Country GetCountryByid(int Id)
        {
            return _countryRepo.Find(Id);
        }
    }
}
