using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Modal
{
    public partial class Modal
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string Size { get; set; } = "xl";

        public bool Show { get; set; }

        public void Open()
        {
            Show = true;
            StateHasChanged();
        }

        public void Close()
        {
            Show = false;
            StateHasChanged();
        }
    }
}
