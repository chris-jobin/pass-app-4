using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : PassAppValidationAttribute
    {
        public RequiredAttribute()
        { }

        public override bool Validate(object value, out string message)
        {
            message = ErrorMessage;
            return value switch
            {
                var val when val is string stringVal => !string.IsNullOrEmpty(stringVal),
                var val when val is int intVal => intVal > 0,
                _ => false
            };
        }
    }
}
