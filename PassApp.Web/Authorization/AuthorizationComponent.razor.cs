using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Authorization
{
    public partial class AuthorizationComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        public bool IsAuthorized { get; set; }
        public Modal.Modal? ModalRef { get; set; }
        public AuthorizationType AuthType { get; set; }

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

        protected async Task Register()
        {

        }

        protected async Task ToggleAuthType()
        {
            AuthType = AuthType == AuthorizationType.Login ? AuthorizationType.Register : AuthorizationType.Login;
            StateHasChanged();
            await Task.Yield();
        }

        public enum AuthorizationType
        {
            Login,
            Register
        }
    }
}
