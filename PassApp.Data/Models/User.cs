using PassApp.Data.Models.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Data.Models
{
    public class User : Keyable
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
