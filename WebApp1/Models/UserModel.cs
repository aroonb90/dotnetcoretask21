using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApp1.Attributes;

namespace WebApp1.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Contact")]
        public string Contact { get; set; }

        [ValidateDropdownList(ErrorMessage ="Please select Country")]
        public bool Country { get; set; }

        [ValidateDropdownList(ErrorMessage = "Please select City")]
        public bool City { get; set; }
        
        public string Gender { get; set; }
        
        [ValidateCheckBox(ErrorMessage ="Please select Terms")]
        public bool Terms { get; set; }


    }
}
