using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore2WebApiAuth.ViewModels
{
    public class CredentialsViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
