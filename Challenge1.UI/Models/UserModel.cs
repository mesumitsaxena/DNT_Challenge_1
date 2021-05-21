using Challenge1.UI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge1.UI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't  match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [RegularExpression("^[6,7,8,9]\\d{9}$", ErrorMessage = "Please Enter Valid Contact.")]
        public string PhoneNumber { get; set; }
        [CheckBoxValidator(ErrorMessage = "Please Accept Terms!!")]
        public bool Terms { get; set; }
    }
}
