using Bogus;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class DeleteForm
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        public string ConfirmationText { get; set; }
        public string ConfirmationTextMatch { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ConfirmationTextMatch = new Faker().Lorem.Word();
            StateHasChanged();
            await Task.Yield();
        }

        private async Task Delete()
        {
            if (OnDelete.HasDelegate)
                await OnDelete.InvokeAsync();
        }

        private async Task Close()
        {
            if (OnClose.HasDelegate)
                await OnClose.InvokeAsync();
        }
    }
}
