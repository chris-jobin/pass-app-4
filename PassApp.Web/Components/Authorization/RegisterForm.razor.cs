using Microsoft.AspNetCore.Components;
using PassApp.Web.Components.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Authorization
{
    public partial class RegisterForm
    {
        [Parameter]
        public EventCallback OnRegister { get; set; }
        [Parameter]
        public EventCallback OnLogin { get; set; }
        public RegisterFormModel? Model { get; set; } = new();
        public ValidationForm? Context { get; set; }

        protected async Task Register()
        {
            if (Context.IsValid() && OnRegister.HasDelegate)
                await OnRegister.InvokeAsync();
        }

        protected async Task Login()
        {
            if (OnLogin.HasDelegate)
                await OnLogin.InvokeAsync();
        }
    }
}
