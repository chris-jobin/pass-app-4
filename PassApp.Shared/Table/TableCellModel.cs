using PassApp.Shared.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Table
{
    public class TableCellModel
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public string? Link { get; set; }
        public bool ShowButton { get; set; }
    }
}
