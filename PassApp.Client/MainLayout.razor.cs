using PassApp.Client.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client
{
    public partial class MainLayout
    {
        public AuthorizationComponent Auth { get; set; }

        private void Logout() => Auth.UnAuthorize();
        private void Delete() => Auth.DeleteProfile();
    }
}
