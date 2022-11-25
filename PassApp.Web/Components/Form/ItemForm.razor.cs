using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PassApp.Web.Components.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Form
{
    public partial class ItemForm
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        public ItemFormModel? Model { get; set; }
        public ValidationForm? Context { get; set; }
        public Modal.Modal? ModalRef { get; set; }
        public PasswordForm? FormRef { get; set; }

        public bool ShowPassword { get; set; }
        public string InputType => ShowPassword ? "text" : "password";

        protected override async Task OnInitializedAsync()
        {
            Model = new();
            Model.Categories = new List<string>
            {
                "General",
                "Banking",
                "Social"
            };
            await Task.Yield();
        }

        protected async Task CopyToClipboard() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Model?.Password ?? "");

        protected async Task SavePassword()
        {
            ModalRef?.Close();
            Model.Password = FormRef?.Model.Password;
            await Task.Yield();
        }
    }
}
