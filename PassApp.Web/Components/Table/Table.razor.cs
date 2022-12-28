using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Table
{
    public partial  class Table
    {
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

        public async Task Refresh()
        {
            StateHasChanged();
            await Task.Yield();
        }

        protected void ChangePage(int page)
        {
            Model?.ChangePage(page);
        }
    }
}
