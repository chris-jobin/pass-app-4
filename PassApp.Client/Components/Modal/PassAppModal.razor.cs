using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Modal
{
    public partial class PassAppModal
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Size { get; set; } = "lg";
        [Parameter]
        public bool Centered { get; set; }
        [Parameter]
        public bool ShowOnLoad { get; set; }
        [Parameter]
        public bool HideFooter { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        private bool Show { get; set; }
        private bool IsOperating { get; set; }
        private string CenteredClass => Centered ? "modal-dialog-centered" : "";

        protected override async Task OnInitializedAsync()
        {
            if (ShowOnLoad)
                Open();
            await Task.Yield();
        }

        public void Open() => Show = true;
        public void Close() => Show = false;

        private async Task Save()
        {
            Operate();
            if (OnSave.HasDelegate)
                await OnSave.InvokeAsync();
            Operate();
        }

        private void Operate()
        {
            IsOperating = !IsOperating;
            StateHasChanged();
        }
    }
}
