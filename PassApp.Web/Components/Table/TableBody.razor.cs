using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Table
{
    public partial class TableBody
    {
        [CascadingParameter]
        public Table? Table { get; set; }
        [Parameter]
        public TableModel? Model { get; set; }
        [Parameter]
        public EventCallback<string[]> Action { get; set; }

        [Inject]
        public IJSRuntime Js { get; set; }

        protected async Task OnClick(string[]? args)
        {
            if (Action.HasDelegate)
                await Action.InvokeAsync(args);
        }

        protected void OnFilterText(int index, string? filterText)
        {
            Model?.Filter(index, filterText);
            Table?.Refresh();
        }

        protected async Task CopyToClipboard(string text)
        {
            await Js.InvokeVoidAsync("CopyToClipboard", text);
        }

        protected async Task ShowButton(TableCellModel cell)
        {
            cell.ShowButton = true;
            await Task.Yield();
        }
    }
}
