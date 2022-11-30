using PassApp.Web.Components.Validation.Attributes;
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

        [DisplayValidation("Category")]
        [StringValidation("Category is required.")]
        public string? Category { get; set; }
        public List<string>? Categories { get; set; }

        [DisplayValidation("Title")]
        [StringValidation("Title is required.")]
        public string? Title { get; set; }

        [DisplayValidation("Link")]
        public string? Link { get; set; }

        [DisplayValidation("Username")]
        [StringValidation("Username is required.")]
        public string? Username { get; set; }

        [DisplayValidation("Email")]
        [StringValidation("Email is required.")]
        public string? Email { get; set; }

        [DisplayValidation("Password")]
        [StringValidation("Password is required.")]
        public string? Password { get; set; }

        [DisplayValidation("Notes")]
        public string? Notes { get; set; }
    }
}
