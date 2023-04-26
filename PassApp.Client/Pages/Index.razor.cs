using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PassApp.Client.Components.Form;
using PassApp.Client.Components.Modal;
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
        public PassAppModal ModalRef { get; set; }
        public RecordForm FormRef { get; set; }
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Records = await Context.Records.ToListAsync();
            Categories = await Context.GetDistinctCategories();
        }

        private void Open() => ModalRef.Open();
        private void Close() => ModalRef.Close();
        private async Task SaveRecord() => await FormRef.Save();
        private void TableAction(string id)
        {
            Id = id;
            Open();
        }
        private async Task Refresh()
        {
            Records = await Context.Records.ToListAsync();
            Categories = await Context.GetDistinctCategories();
            Close();
        }
    }
}
