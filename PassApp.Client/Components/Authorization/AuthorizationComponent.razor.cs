using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PassApp.Client.Components.Form;
using PassApp.Client.Components.Modal;
using PassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Authorization
{
    public partial class AuthorizationComponent
    {
        [Inject]
        public PassAppContext Context { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        public bool IsAuthorized { get; set; }
        private bool HasUser { get; set; }
        public bool IsError { get; set; }
        public MessageComponent Message { get; set; }
        public PassAppModal Delete { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HasUser = await Context.Users.AnyAsync();
        }

        public void Authorize() => IsAuthorized = true;
        public void UnAuthorize() => IsAuthorized = false;

        private async Task Login(LoginModel model)
        {
            if (await Context.Login(model.Username, model.Password))
                Authorize();
            else
                await Message.SetMessage("Login Error", null, MessageType.Error);
        }

        private async Task Register(RegisterModel model)
        {
            if (await Context.RegisterUser(model.Username, model.Password))
                HasUser = true;
            else
                await Message.SetMessage("Register Error", null, MessageType.Error);
        }

        public void DeleteProfile() => Delete.Open();
        private void DeleteClose() => Delete.Close();
        private async Task OnDeleteProfile()
        {
            if (await Context.DeleteUser())
            {
                UnAuthorize();
                HasUser = false;
            }
        }
    }
}
