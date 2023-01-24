using PassApp.Shared.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Authorization
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
