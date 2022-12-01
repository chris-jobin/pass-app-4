using PassApp.Web.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Login
{
    public class LoginModel
    {
        [DisplayValidation("Username")]
        [StringValidation("Username is required.")]
        public string? Username { get; set; }

        [DisplayValidation("Password")]
        [StringValidation("Password is required.")]
        public string? Password { get; set; }

        public void Clear()
        {
            Username = null;
            Password = null;
        }
    }
}
