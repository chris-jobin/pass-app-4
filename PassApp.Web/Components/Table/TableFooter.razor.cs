using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Table
{
    public partial class TableFooter
    {
        [CascadingParameter]
        public Table? Table { get; set; }
        [Parameter]
        public TableModel? Model { get; set; }
        [Parameter]
        public EventCallback<string[]> Action { get; set; }

        protected async Task OnClick(string[] args)
        {
            if (Action.HasDelegate)
                await Action.InvokeAsync(args);
        }
    }
}
