using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Buttons
{
    public partial class IconButton
    {
        [Parameter]
        public string IconClass { get; set; } = "oi oi-pencil text-primary";
        [Parameter]
        public EventCallback<string[]> OnClick { get; set; }
        [Parameter]
        public string? IconText { get; set; }
        [Parameter]
        public string[]? Parameters { get; set; }

        protected async Task Clicked()
        {
            await OnClick.InvokeAsync(Parameters);
        }
    }
}
