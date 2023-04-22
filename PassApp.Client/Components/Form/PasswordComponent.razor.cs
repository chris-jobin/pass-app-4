using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class PasswordComponent
    {
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        [Parameter]
        public string Id { get; set; }
        public bool ShowValue { get; set; }

        private async Task OnValueChanged(string value)
        {
            Value = value;
            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(value);
        }

        private void Show() => ShowValue = true;
        private void Hide() => ShowValue = false;
    }
}
