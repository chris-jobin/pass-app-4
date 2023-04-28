using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PassApp.Client.Components.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class NewPasswordComponent
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        private bool ShowPassword { get; set; }
        private PassAppModal ModalRef { get; set; }
        private PasswordForm FormRef { get; set; }

        private async Task OnValueChanged(string value)
        {
            Value = value;
            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(value);
        }

        private void Show() => ShowPassword = true;
        private void Hide() => ShowPassword = false;
        private async Task Copy() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Value);
        private void Open() => ModalRef.Open();
        private void Close() => ModalRef.Close();
        private async Task GetPassword()
        {
            await OnValueChanged(FormRef.Model.Password);
            Close();
        }
    }
}
