using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace PassApp.Web.Components.Validation
{
    public partial class ValidationComponent
    {
        [CascadingParameter]
        public ValidationForm? Form { get; set; }
        [Parameter]
        public Expression<Func<object>>? For { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Form == null || For == null)
                return;

            var expression = GetMemberExpression();

            if (expression == null)
                return;

            Form.AddChild(this);

            var attr = expression?.Member.GetCustomAttribute<ValidateAttribute>();
            if (attr != null && attr.Required)
                ErrorMessage = $"{expression?.Member.Name} is required.";

            await Task.Yield();
        }

        private MemberExpression? GetMemberExpression()
        {
            var member = For?.Body as MemberExpression;
            var unary = For?.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }

        public bool Validate()
        {
            if (Form == null || For == null)
                return true;

            var expression = GetMemberExpression();

            if (expression == null)
                return true;

            var attr = expression?.Member.GetCustomAttribute<ValidateAttribute>();
            if (attr != null)
            {
                IsError = true;
                IsError = attr.Required && IsError;
            }

            StateHasChanged();

            return !IsError;
        }
    }
}
