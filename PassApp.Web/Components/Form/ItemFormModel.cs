using PassApp.Web.Components.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Form
{
    public class ItemFormModel
    {
        public string? Id { get; set; }

        [Validate("Category", Required = true)]
        public string? Category { get; set; }
        public List<string>? Categories { get; set; }

        [Validate("Title", Required = true)]
        public string? Title { get; set; }

        public string? Link { get; set; }

        [Validate("Username", Required = true)]
        public string? Username { get; set; }

        [Validate("Email", Required = true)]
        public string? Email { get; set; }

        [Validate("Password", Required = true)]
        public string? Password { get; set; }
        public string? Notes { get; set; }
    }
}
