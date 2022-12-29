using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Validation
{
    public partial class ValidationForm
    {
        [Parameter]
        public object? Model { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        public List<ValidationComponent> Children { get; set; } = new();

        internal void AddChild(ValidationComponent child) => Children.Add(child);

        public bool IsValid()
        {
            var isvalid = true;
            foreach (var child in Children)
                isvalid = child.Validate() && isvalid;
            return isvalid;
        }
    }
}
