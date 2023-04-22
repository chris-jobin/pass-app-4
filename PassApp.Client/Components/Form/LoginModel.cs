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
        public string Username { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
