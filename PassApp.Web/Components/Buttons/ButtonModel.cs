using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Buttons
{
    public class ButtonModel
    {
        public string? Id { get; set; }
        public string? BtnClass { get; set; }
        public string? BtnText { get; set; }
        public string[]? Parameters { get; set; }
    }
}
