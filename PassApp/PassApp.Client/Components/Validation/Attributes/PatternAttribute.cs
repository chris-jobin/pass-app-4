using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PatternAttribute : PassAppValidationAttribute
    {
        public string Pattern { get; set; }

        public PatternAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public override bool Validate(object value, out string message)
        {
            message = ErrorMessage;
            if (value is not string)
                return false;

            var regex = new Regex(Pattern);
            return regex.IsMatch((string)value);
        }
    }
}
