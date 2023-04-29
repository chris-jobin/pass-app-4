using Microsoft.AspNetCore.Components;
using PassApp.Client.Components.Modal;
using PassApp.Data;
using PassApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class RecordForm
    {
        [Inject]
        public PassAppContext Context { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        public Validation.Form FormRef { get; set; }
        public RecordModel Model { get; set; }
        public DeleteModal DeleteRef { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var id = Guid.TryParse(Id, out var guid) ? guid : Guid.NewGuid();
            var record = await Context.GetRecordForDisplay(id);
            Model = new RecordModel(record);
        }

        public async Task Save()
        {
            if (FormRef.Validate())
            {
                var record = new Record
                {
                    Id = Model.Id,
                    Category = Model.Category,
                    Title = Model.Title,
                    Link = Model.Link,
                    Username = Model.Username,
                    Email = Model.Email,
                    Password = Model.Password,
                    Notes = Model.Notes
                };
                if (await Context.SetRecord(record) && OnSave.HasDelegate)
                    await OnSave.InvokeAsync();

            }
        }

        private void Delete() => DeleteRef.Open();
        private async Task OnDelete()
        {
            if (await Context.DeleteRecord(Model.Id) && OnSave.HasDelegate)
                await OnSave.InvokeAsync();
        }
    }
}
