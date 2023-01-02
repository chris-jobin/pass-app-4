using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Table
{
    public partial  class Table
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public TableModel? Model { get; set; }
        [Parameter]
        public EventCallback<string[]> Action { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model != null)
            {
                Model.DisplayItems = Model.StoredItems;
                if (Model.HasPaging)
                    Model.ChangePage(1);
            }
            await Task.Yield();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                await Js.InvokeVoidAsync("SetResize", DotNetObjectReference.Create(this));
            await Js.InvokeVoidAsync("UpdateItemsPerPage", DotNetObjectReference.Create(this));
        }

        public async Task Refresh()
        {
            StateHasChanged();
            await Task.Yield();
        }

        protected void ChangePage(int page)
        {
            Model?.ChangePage(page);
        }

        [JSInvokable("UpdateItemsPerPage")]
        public async Task UpdateItemsPerPage(int itemsPerPage)
        {
            if (Model.ItemsPerPage != itemsPerPage)
            {
                Model.ItemsPerPage = itemsPerPage;
                if (Model.CurrentPage > Model.NumberOfPages)
                    Model.ChangePage(Model.NumberOfPages);
                StateHasChanged();
            }
            await Task.Yield();
        }
    }
}
