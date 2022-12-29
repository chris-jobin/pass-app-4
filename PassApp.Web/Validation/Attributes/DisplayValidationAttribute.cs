using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayValidationAttribute : Attribute
    {
        public string? Name { get; set; }

        public DisplayValidationAttribute(string? name)
        {
            Name = name;
        }
    }
}
