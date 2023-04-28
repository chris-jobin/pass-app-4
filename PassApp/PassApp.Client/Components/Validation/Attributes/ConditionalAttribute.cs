using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConditionalAttribute : PassAppValidationAttribute
    {
        public ConditionalAttribute()
        { }

        public override bool Validate(object value, out string message)
        {
            message = ErrorMessage;
            return (value as bool?) ?? false;
        }
    }
}
