using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Modal
{
    public partial class Modal
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string Size { get; set; } = "lg";
        [Parameter]
        public bool Centered { get; set; }
        [Parameter]
        public bool ShowOnLoad { get; set; }
        [Parameter]
        public bool HideTopAndBottom { get; set; }
        [Parameter]
        public EventCallback Save { get; set; }

        public bool Show { get; set; }
        public bool IsOperating { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ShowOnLoad)
                Open();
            await Task.Yield();
        }

        public void Open()
        {
            Show = true;
        }

        public void Close()
        {
            Show = false;
        }

        protected async Task OnSave()
        {
            Operate();
            if (Save.HasDelegate)
                await Save.InvokeAsync();
            Operate();
        }

        protected void Operate()
        {
            IsOperating = !IsOperating;
            StateHasChanged();
        }
    }
}
