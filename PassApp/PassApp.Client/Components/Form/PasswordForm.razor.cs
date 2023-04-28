using Bogus.Bson;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class PasswordForm
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        public PasswordModel Model { get; set; } = new();

        private void LengthChanged(int num) => Model.PasswordLength = num;
        private async Task Copy() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Model.Password);
    }
}
