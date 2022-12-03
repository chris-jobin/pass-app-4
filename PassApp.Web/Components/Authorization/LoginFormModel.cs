using PassApp.Web.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Authorization
{
    public class LoginFormModel
    {
        [DisplayValidation("Username")]
        [StringValidation("Username is required.")]
        public string? Username { get; set; }

        [DisplayValidation("Password")]
        [StringValidation("Password is required.")]
        public string? Password { get; set; }
    }
}
