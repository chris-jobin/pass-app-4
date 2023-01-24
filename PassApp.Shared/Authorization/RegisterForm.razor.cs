using Microsoft.AspNetCore.Components;
using PassApp.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Authorization
{
    public partial class RegisterForm
    {
        [Parameter]
        public EventCallback OnRegister { get; set; }
        public RegisterFormModel? Model { get; set; } = new();
        public ValidationForm? Context { get; set; }
        public bool RegisterError { get; set; }

        protected async Task Register()
        {
            if (Context.IsValid() && OnRegister.HasDelegate)
                await OnRegister.InvokeAsync();
        }
    }
}
