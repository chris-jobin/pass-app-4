using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Table
{
    public partial class PassAppTableFilter
    {
        [CascadingParameter]
        public PassAppTable Table { get; set; }
        [Parameter]
        public string Property { get; set; }
        [Parameter]
        public List<string> DropDownItems { get; set; }
        [Parameter]
        public EventCallback OnInput { get; set; }
        public string FilterText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Table == null)
                throw new NullReferenceException($"{this.GetType().Name} must be within {Table.GetType().Name}");
            Table.AddFilter(this);
            await Task.Yield();
        }

        private async Task Input(string value)
        {
            FilterText = value;
            if (OnInput.HasDelegate)
                await OnInput.InvokeAsync();
        }
    }
}
