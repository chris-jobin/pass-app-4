using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Table
{
    public partial class PassAppTablePaging
    {
        [Parameter]
        public int CurrentPage { get; set; }
        [Parameter]
        public int NumberOfPages { get; set; }
        [Parameter]
        public EventCallback<int> OnCurrentPageChanged { get; set; }

        protected async Task CurrentPageChanged(int page)
        {
            if (OnCurrentPageChanged.HasDelegate)
                await OnCurrentPageChanged.InvokeAsync(page);
        }
    }
}
