using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Form
{
    public partial class ItemForm
    {
        public ItemFormModel? Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = new();
            await Task.Yield();
        }
    }
}
