using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Buttons
{
    public partial class Button
    {
        [Parameter]
        public string BtnClass { get; set; } = "btn btn-primary";
        [Parameter]
        public string BtnText { get; set; } = "Button";
        [Parameter]
        public EventCallback<string[]> OnClick { get; set; }
        [Parameter]
        public string[]? Parameters { get; set; }

        protected async Task Clicked()
        {
            await OnClick.InvokeAsync(Parameters);
        }
    }
}
