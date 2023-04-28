using PassApp.Client.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public class LoginModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
