using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConditionalValidationAttribute : Attribute
    {
        public string? ErrorMessage { get; set; }

        public ConditionalValidationAttribute(string errormessage) 
        {
            ErrorMessage = errormessage;
        }
    }
}
