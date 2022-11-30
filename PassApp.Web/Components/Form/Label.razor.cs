using Microsoft.AspNetCore.Components;
using PassApp.Web.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Form
{
    public partial class Label
    {
        [Parameter]
        public Expression<Func<object>>? For { get; set; }
        public string? Text { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var expression = GetMemberExpression();

            if (expression == null)
                return;

            var attr = ((PropertyInfo)expression.Member).GetCustomAttribute<DisplayValidationAttribute>();

            if (attr == null)
                return;

            Text = attr.Name;

            await Task.Yield();
        }

        private MemberExpression? GetMemberExpression()
        {
            var member = For?.Body as MemberExpression;
            var unary = For?.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }
    }
}
