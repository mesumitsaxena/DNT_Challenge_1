using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }


        public List<City> Cities { get; set; }
    }
}
