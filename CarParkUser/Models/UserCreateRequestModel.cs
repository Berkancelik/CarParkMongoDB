using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarParkUser.Models
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("NameSurname")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("JobTitle")]
        public string JobTitle { get; set; }


    }
}
