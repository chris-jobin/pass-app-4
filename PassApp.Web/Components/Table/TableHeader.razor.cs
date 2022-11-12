using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Table
{
    public partial class TableHeader
    {
        [CascadingParameter]
        public Table? Table { get; set; }
        [Parameter]
        public TableModel? Model { get; set; }

        protected void OnSort(int index)
        {
            Model?.Sort(index);
            Table?.Refresh();
        }

        protected void OnFilterText(int index, string? filterText)
        {
            Model?.Filter(index, filterText);
            Table?.Refresh();
        }
    }
}
