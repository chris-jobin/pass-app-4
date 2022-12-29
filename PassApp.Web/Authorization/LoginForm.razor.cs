using Microsoft.AspNetCore.Components;
using PassApp.Web.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Authorization
{
    public partial class LoginForm
    {
        [Parameter]
        public EventCallback OnLogin { get; set; }
        [Parameter]
        public EventCallback OnRegister { get; set; }
        public LoginFormModel? Model { get; set; } = new();
        public ValidationForm? Context { get; set; }

        protected async Task Login()
        {
            if (Context.IsValid() && OnLogin.HasDelegate)
                await OnLogin.InvokeAsync();
        }

        protected async Task Register()
        {
            if (OnRegister.HasDelegate)
                await OnRegister.InvokeAsync();
        }
    }
}
