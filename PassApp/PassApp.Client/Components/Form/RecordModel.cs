using PassApp.Client.Components.Validation.Attributes;
using PassApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public class RecordModel
    {
        public Guid Id { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
        public List<string> Categories { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [DisplayName("Link")]
        public string Link { get; set; }

        [Conditional(ErrorMessage = "Username or Email is required.")]
        public bool UsernameOrEmail => !string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Email);

        [DisplayName("Username")]
        public string Username { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        public RecordModel(Record record)
        {
            Id = record?.Id ?? Guid.NewGuid();
            Category = record?.Category;
            Title = record?.Title;
            Link = record?.Link;
            Username = record?.Username;
            Email = record?.Email;
            Password = record?.Password;
            Notes = record?.Notes;
        }
    }
}
