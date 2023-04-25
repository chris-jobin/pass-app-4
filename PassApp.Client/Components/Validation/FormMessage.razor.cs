using Microsoft.AspNetCore.Components;
using PassApp.Client.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation
{
    public partial class FormMessage
    {
        [CascadingParameter]
        public Form Form { get; set; }
        [Parameter]
        public Expression<Func<object>> For
        {
            get => _For;
            set
            {
                _For = value;
                if (IsValidated)
                    Validate();
            }
        }
        private Expression<Func<object>> _For;
        public List<string> Errors { get; set; } = new List<string>();
        private bool IsValidated { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Form == null)
                throw new NullReferenceException($"{this.GetType().Name} must be within {Form.GetType().Name}");
            Form.AddMessage(this);
            await Task.Yield();
        }

        public bool Validate()
        {
            IsValidated = true;
            Errors = new List<string>();
            var info = GetPropertyInfoFromExpression();
            var value = info.GetValue(Form.Model, null);
            var attributes = info.GetCustomAttributes(false);
            foreach ( var attribute in attributes)
            {
                if (attribute is not PassAppValidationAttribute)
                    continue;
                if (!((PassAppValidationAttribute)attribute).Validate(value, out string errorMessage))
                    Errors.Add(errorMessage);
            }
            return !Errors.Any();
        }

        private PropertyInfo GetPropertyInfoFromExpression()
        {
            var expression = For.Body switch
            {
                var body when body is MemberExpression member => member,
                var body when body is UnaryExpression unary => (MemberExpression)unary.Operand,
                _ => throw new InvalidOperationException()
            };
            var propertyInfo = (PropertyInfo)expression.Member;
            return propertyInfo;
        }
    }
}
