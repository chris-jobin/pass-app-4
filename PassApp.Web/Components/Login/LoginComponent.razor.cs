using Microsoft.AspNetCore.Components;
using PassApp.Web.Components.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Login
{
    public partial class LoginComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        protected LoginModel? Model { get; set; }
        protected ValidationForm? Context { get; set; }
        protected bool IsAuthorized { get; set; }
        protected Modal.Modal? ModalRef { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = new();
            await Task.Yield();
        }

        protected async Task Login()
        {
            if (Context.IsValid())
            {
                IsAuthorized = true;
                Model.Clear();
                StateHasChanged();
                await Task.Yield();
            }
        }

        public async Task Logout()
        {
            IsAuthorized = false;
            Model.Clear();
            StateHasChanged();
            await Task.Yield();
        }
    }
}
