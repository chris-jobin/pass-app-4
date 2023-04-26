using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation
{
    public partial class FormRow
    {
        [CascadingParameter]
        public Form Form { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public Expression<Func<object>> For { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public int LabelWidth { get; set; } = 4;
        private string LabelCssClass => $"col-sm-{LabelWidth} col-form-label";

        protected override async Task OnInitializedAsync()
        {
            if (Form == null)
                throw new NullReferenceException($"{this.GetType().Name} must be within {Form.GetType().Name}");
            Form.AddRow(this);
            await Task.Yield();
        }
    }
}
