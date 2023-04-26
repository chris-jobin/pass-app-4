using Microsoft.AspNetCore.Components;
using PassApp.Client.Components.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class Label
    {
        [Parameter]
        public Expression<Func<object>> For { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public string CssClass { get; set; }
        public string Text { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var expression = For?.Body switch
            {
                var body when body is MemberExpression => body as MemberExpression,
                var body when body is UnaryExpression operand => operand.Operand as MemberExpression,
                _ => throw new NullReferenceException($"{this.GetType().Name} requires a {For.GetType().Name} parameter")
            };
            var propertyInfo = (PropertyInfo)expression.Member;
            var displayNameAttribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
            var requiredAttribute = propertyInfo.GetCustomAttribute<RequiredAttribute>();
            if (displayNameAttribute == null)
                return;
            Text = displayNameAttribute.DisplayName;
            if (requiredAttribute != null)
                Text += @"<span class=""validation-message"">*</span>";
            await Task.Yield();
        }
    }
}
