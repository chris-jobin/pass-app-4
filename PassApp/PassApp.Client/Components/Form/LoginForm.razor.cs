using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class LoginForm
    {
        [Parameter]
        public EventCallback<LoginModel> OnLogin { get; set; }
        public LoginModel Model { get; set; } = new();
        public Validation.Form FormRef { get; set; }

        protected async Task Login()
        {
            if (OnLogin.HasDelegate)
                await OnLogin.InvokeAsync(Model);
        }
    }
}
