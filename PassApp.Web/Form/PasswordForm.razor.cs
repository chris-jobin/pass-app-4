using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Form
{
    public partial class PasswordForm
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        public PasswordFormModel Model { get; set; } = new();

        protected async Task OnLengthChange(int num)
        {
            Model.PasswordLength = num;
            StateHasChanged();
            await Task.Yield();
        }

        protected async Task CopyToClipboard() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Model?.Password ?? "");
    }
}
