
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Entities
{
    public class User:IdentityUser<int>
    {
        public string Name { get; set; }
        public int  CountryId { get; set; }
        public int CityId { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }
    }
}
