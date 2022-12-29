using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Form
{
    public partial class PasswordComponent
    {
        [Parameter]
        public string? Value 
        {
            get => _Value;
            set
            {
                if (_Value == value) 
                    return;
                _Value = value;
                ValueChanged.InvokeAsync(value);
            }
        }
        public string? _Value;

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        public bool ShowValue { get; set; }
    }
}
