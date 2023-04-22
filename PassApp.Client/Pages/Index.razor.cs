using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PassApp.Data;
using PassApp.Data.Models;
using System;
using System.Text;

namespace PassApp.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public PassAppContext Context { get; set; }
        private List<Record> Records { get; set; }
        private List<string> Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Records = await Context.Records.ToListAsync();
            Categories = await Context.GetDistinctCategories();
        }
    }
}
