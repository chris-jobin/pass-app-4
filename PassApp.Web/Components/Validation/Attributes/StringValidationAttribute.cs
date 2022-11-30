using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringValidationAttribute : Attribute
    {
        public string? ErrorMessage { get; set; }

        public StringValidationAttribute(string errormessage)
        {
            ErrorMessage = errormessage;
        }
    }
}
