using Bogus;
using PassApp.Client.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Modal
{
    public class DeleteModel
    {
        [Required(ErrorMessage = "Confirmation Text is required.")]
        public string ConfirmationText { get; set; }
        public string ConfirmationTextSource { get; set; }

        [Conditional(ErrorMessage = "Confirmation Text must match.")]
        public bool ConfirmationTextMatch => ConfirmationText == ConfirmationTextSource;

        public DeleteModel()
        {
            ConfirmationTextSource = new Faker().Lorem.Word();
        }
    }
}
