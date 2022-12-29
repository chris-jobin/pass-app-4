using PassApp.Web.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Authorization
{
    public class RegisterFormModel
    {
        [DisplayValidation("Username")]
        [StringValidation("Username is required.")]
        public string? Username { get; set; }

        [DisplayValidation("Password")]
        [StringValidation("Password is required.")]
        public string? Password { get; set; }

        [DisplayValidation("Confirm Password")]
        [StringValidation("Must confirm password.")]
        public string? ConfirmPassword { get; set; }

        [ConditionalValidation("Passwords must match.")]
        public bool PasswordMatch => Password == ConfirmPassword;
    }
}
