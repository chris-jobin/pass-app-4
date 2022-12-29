using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PassApp.Data;
using PassApp.Web.Authorization;
using PassApp.Web.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client
{
    public partial class AuthorizationComponent
    {
        [Inject]
        public PassAppContext? PassAppContext { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        public bool IsAuthorized { get; set; }
        public Modal? ModalRef { get; set; }
        public LoginForm? LoginRef { get; set; }
        public RegisterForm? RegisterRef { get; set; }
        public bool HasUser { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            HasUser = await PassAppContext.Users.AnyAsync();
        }

        public async Task Authorize()
        {
            IsAuthorized = true;
            StateHasChanged();
            await Task.Yield();
        }

        public async Task UnAuthorize()
        {
            IsAuthorized = false;
            StateHasChanged();
            await Task.Yield();
        }

        protected async Task Login()
        {
            var username = LoginRef?.Model?.Username;
            var password = LoginRef?.Model?.Password;
            if (await PassAppContext.Login(username, password))
            {
                LoginRef.LoginError = false;
                await Authorize();
            }
            else
                LoginRef.LoginError = true;
        }

        protected async Task Register()
        {
            var username = RegisterRef?.Model?.Username;
            var password = RegisterRef?.Model?.Password;
            if (await PassAppContext.Register(username, password))
            {
                RegisterRef.RegisterError = false;
                HasUser = true;
                StateHasChanged();
            }
            else
                RegisterRef.RegisterError = true;
        }
    }
}
