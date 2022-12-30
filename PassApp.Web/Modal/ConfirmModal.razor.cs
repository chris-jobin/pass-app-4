using Bogus;
using Microsoft.AspNetCore.Components;
using PassApp.Web.Validation;
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
        [Parameter]
        public bool RequireConfirmation { get; set; }

        public bool Show { get; set; }
        public bool IsOperating { get; set; }
        public string? ConfirmationText { get; set; }
        public string? ConfirmationTextMatch { get; set; }

        public void Open()
        {
            Show = true;
            if (RequireConfirmation)
            {
                ConfirmationText = default;
                ConfirmationTextMatch = new Faker().Lorem.Word();
            }
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
