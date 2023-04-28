using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation.Attributes
{
    public abstract class PassAppValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public abstract bool Validate(object value, out string message);
    }
}
