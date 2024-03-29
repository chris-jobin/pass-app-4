﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class RegisterForm
    {
        [Parameter]
        public EventCallback<RegisterModel> OnRegister { get; set; }
        public RegisterModel Model { get; set; } = new();
        public Validation.Form FormRef { get; set; }

        private async Task Register()
        {
            if (FormRef.Validate() && OnRegister.HasDelegate)
                await OnRegister.InvokeAsync(Model);
        }
    }
}
