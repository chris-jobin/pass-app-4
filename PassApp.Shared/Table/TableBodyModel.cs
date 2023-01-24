using PassApp.Shared.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Shared.Table
{
    public class TableBodyModel
    {
        public string? Id { get; set; }
        public List<TableCellModel>? Content { get; set; }
        public List<IconButtonModel>? Buttons { get; set; }
    }
}
