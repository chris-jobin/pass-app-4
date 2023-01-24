using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using PassApp.Shared.Validation.Attributes;

namespace PassApp.Shared.Validation
{
    public partial class ValidationComponent
    {
        [CascadingParameter]
        public ValidationForm? Form { get; set; }
        [CascadingParameter]
        public object? Model { get; set; }
        [Parameter]
        public Expression<Func<object>>? For { get; set; }
        public bool IsValid { get; set; } = true;
        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Form == null || For == null)
                return;

            var expression = GetMemberExpression();

            if (expression == null)
                return;

            Form.AddChild(this);

            await Task.Yield();
        }

        private MemberExpression? GetMemberExpression()
        {
            var member = For?.Body as MemberExpression;
            var unary = For?.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }

        private static object[] GetAttributes(MemberExpression expression)
        {
            var propertyInfo = (PropertyInfo)expression.Member;
            var attrs = propertyInfo.GetCustomAttributes(false);
            return attrs;
        }

        private object? GetValue(MemberExpression expression)
        {
            var propertyInfo = (PropertyInfo)expression.Member;
            var value = propertyInfo.GetValue(Model);
            return value;
        }

        public bool Validate()
        {
            if (Form == null || For == null)
                return true;

            var expression = GetMemberExpression();

            if (expression == null)
                return true;

            var attrs = GetAttributes(expression);

            if (attrs == null)
                return true;

            var value = GetValue(expression);

            IsValid = true;

            foreach (var attr in attrs)
            {
                if (attr is StringValidationAttribute)
                    IsValid = ValidateStringValidation(attr as StringValidationAttribute, value as string) && IsValid;
                if (attr is ConditionalValidationAttribute)
                    IsValid = ValidateConditionalValidation(attr as ConditionalValidationAttribute, value as bool?) && IsValid;
            }

            StateHasChanged();

            return IsValid;
        }

        private bool ValidateStringValidation(StringValidationAttribute attr, string? value)
        {
            var isvalid = true;
            isvalid = !string.IsNullOrEmpty(value) && isvalid;
            isvalid = !string.IsNullOrWhiteSpace(value) && isvalid;

            if (!isvalid)
                ErrorMessage = attr.ErrorMessage;

            return isvalid;
        }

        private bool ValidateConditionalValidation(ConditionalValidationAttribute attr, bool? value)
        {
            var isvalid = true;
            isvalid = (value as bool? ?? false) && isvalid;

            if (!isvalid)
                ErrorMessage = attr.ErrorMessage;

            return isvalid;
        }
    }
}
