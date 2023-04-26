using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Validation
{
    public partial class Form
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public object Model { get; set; }
        protected List<FormMessage> Messages { get; set; } = new List<FormMessage>();

        protected override async Task OnInitializedAsync()
        {
            if (Model == null)
                throw new NullReferenceException($"{this.GetType()} requires a Model as a parameter.");
            await Task.Yield();
        }
        public void AddMessage(FormMessage message) => Messages.Add(message);

        public bool Validate()
        {
            var isvalid = true;
            foreach (var message in Messages)
                isvalid = message.Validate() && isvalid;
            return isvalid;
        }
    }
}
