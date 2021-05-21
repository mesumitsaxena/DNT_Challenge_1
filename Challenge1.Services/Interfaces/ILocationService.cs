using Challenge1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Services.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<City> GetCitiesBasedonCountry(int CountryId);
        Country GetCountryByid(int Id);
        City GetCityByid(int Id);

    }
}
