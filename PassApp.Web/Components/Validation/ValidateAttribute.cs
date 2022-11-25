using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateAttribute : Attribute
    {
        public string? Name { get; set; }
        public bool Required { get; set; }

        public ValidateAttribute(string name)
        {
            Name = name;
        }
    }
}
