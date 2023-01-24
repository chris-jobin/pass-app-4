using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PassApp.Shared.Modal;
using PassApp.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Form
{
    public partial class ItemForm
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public ItemFormModel? Model { get; set; }
        [Parameter]
        public EventCallback<string> OnDelete { get; set; }

        public ValidationForm? Context { get; set; }
        public Modal.Modal? ModalRef { get; set; }
        public PasswordForm? FormRef { get; set; }
        public bool ShowCategoryDropDown { get; set; }
        public bool ShowPassword { get; set; }
        public ConfirmModal? DeleteRef { get; set; }

        protected async Task ToggleCategory()
        {
            ShowCategoryDropDown= !ShowCategoryDropDown;
            Model.Category = default;
            StateHasChanged();
            await Task.Yield();
        }

        protected async Task CopyToClipboard() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Model?.Password ?? "");

        protected async Task SavePassword()
        {
            ModalRef?.Close();
            if (Model != null && !string.IsNullOrEmpty(FormRef?.Model.Password))
                Model.Password = FormRef?.Model.Password;
            await Task.Yield();
        }

        protected async Task Delete()
        {
            if (OnDelete.HasDelegate)
                await OnDelete.InvokeAsync(Model?.Id.ToString());
        }
    }
}
