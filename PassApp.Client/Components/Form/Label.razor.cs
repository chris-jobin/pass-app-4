using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string Text { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var expression = For?.Body switch
            {
                var body when body is MemberExpression => body as MemberExpression,
                var body when body is UnaryExpression => ((UnaryExpression)body).Operand as MemberExpression,
                _ => throw new NullReferenceException($"{this.GetType().Name} requires a {For.GetType().Name} parameter")
            };
            var propertyInfo = (PropertyInfo)expression.Member;
            var attribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
            if (attribute == null)
                return;
            Text = attribute.DisplayName;
            await Task.Yield();
        }
    }
}
