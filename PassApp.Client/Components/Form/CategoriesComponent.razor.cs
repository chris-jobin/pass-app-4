using Microsoft.AspNetCore.Components;
using PassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class CategoriesComponent
    {
        [Inject]
        public PassAppContext Context { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        private List<string> Categories { get; set; }
        private bool ShowCategories { get; set; }
        private string ButtonCssClass => ShowCategories ? "btn-secondary" : "btn-outline-secondary";

        protected override async Task OnInitializedAsync()
        {
            await GetCategories();
        }

        public async Task GetCategories()
        {
            Categories = await Context.GetDistinctCategories();
        }

        private async Task OnValueChanged(string value)
        {
            Value = value;
            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(value);
        }

        private void Toggle() => ShowCategories = !ShowCategories; 
    }
}
