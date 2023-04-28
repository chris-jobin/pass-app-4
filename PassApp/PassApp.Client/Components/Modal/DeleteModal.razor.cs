using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Modal
{
    public partial class DeleteModal
    {
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        [Parameter]
        public bool RequireConfirmation { get; set; }
        public PassAppModal ModalRef { get; set; }
        public Validation.Form FormRef { get; set; }
        public DeleteModel Model { get; set; }

        public void Open()
        {
            Model = new DeleteModel();
            ModalRef.Open();
        }
        public void Close() => ModalRef.Close();

        private async Task Delete()
        {
            if ((RequireConfirmation && FormRef.Validate() && OnDelete.HasDelegate) || (!RequireConfirmation && OnDelete.HasDelegate))
                await OnDelete.InvokeAsync();
        }
    }
}
