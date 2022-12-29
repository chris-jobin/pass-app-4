using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Modal
{
    public partial class ConfirmModal
    {
        [Parameter]
        public string CloseText { get; set; } = "Cancel";
        [Parameter]
        public string ConfirmText { get; set; } = "Confirm";
        [Parameter]
        public string ConfirmBtnClass { get; set; } = "btn btn-success";
        [Parameter]
        public bool Centered { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public EventCallback OnConfirm { get; set; }

        public bool Show { get; set; }
        public bool IsOperating { get; set; }

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

        protected async Task Confirm()
        {
            if (OnConfirm.HasDelegate)
                await OnConfirm.InvokeAsync();
        }
    }
}
