using Microsoft.AspNetCore.Components;
using PassApp.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Authorization
{
    public partial class LoginForm
    {
        [Parameter]
        public EventCallback OnLogin { get; set; }
        public LoginFormModel? Model { get; set; } = new();
        public ValidationForm? Context { get; set; }
        public bool LoginError { get; set; }

        protected async Task Login()
        {
            if (Context.IsValid() && OnLogin.HasDelegate)
                await OnLogin.InvokeAsync();
        }
    }
}
