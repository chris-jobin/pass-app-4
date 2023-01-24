using PassApp.Shared.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Form
{
    public class ItemFormModel
    {
        public Guid Id { get; set; }

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
        public string? Username { get; set; }

        [DisplayValidation("Email")]
        public string? Email { get; set; }

        [ConditionalValidation("Username or Email is required.")]
        public bool UsernameEmail => !string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Email);

        [DisplayValidation("Password")]
        [StringValidation("Password is required.")]
        public string? Password { get; set; }

        [DisplayValidation("Notes")]
        public string? Notes { get; set; }
    }
}
