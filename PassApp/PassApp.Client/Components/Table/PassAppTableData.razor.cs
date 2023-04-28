using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Table
{
    public partial class PassAppTableData
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public bool AllowCopy { get; set; }
        [Parameter]
        public string Link { get; set; }

        private bool ShowCopyButton { get; set; }

        private void ShowButton() => ShowCopyButton = true;
        private void HideButton() => ShowCopyButton = false;
        private async Task Copy() => await Js.InvokeVoidAsync("navigator.clipboard.writeText", Value);
    }
}
