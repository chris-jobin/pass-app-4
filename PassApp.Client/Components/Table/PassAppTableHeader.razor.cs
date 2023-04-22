using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Table
{
    public partial class PassAppTableHeader
    {
        [CascadingParameter]
        public PassAppTable Table { get; set; }
        [Parameter]
        public string Header { get; set; }
        [Parameter]
        public string Property { get; set; }
        [Parameter]
        public List<string> DropDownItems { get; set; }
        [Parameter]
        public EventCallback<PassAppTableHeader> OnSort { get; set; }
        [Parameter]
        public bool Filterable { get; set; }
        [Parameter]
        public int Width { get; set; } = 10;
        private string WidthStyle => $"width:{Width}%;";
        public SortDirection Direction { get; set; }
        private string SortIcon => Direction switch
        {
            SortDirection.Ascending => "oi oi-caret-top",
            SortDirection.Descending => "oi oi-caret-bottom",
            _ => ""
        };

        protected override async Task OnInitializedAsync()
        {
            if (Table == null)
                throw new NullReferenceException($"{this.GetType().Name} must be within {Table.GetType().Name}");
            Table.AddHeader(this);
            await Task.Yield();
        }

        private async Task Sort()
        {
            if (OnSort.HasDelegate)
                await OnSort.InvokeAsync(this);
        }

        public void SetNextSort()
        {
            Direction = Direction switch
            {
                SortDirection.Ascending => SortDirection.Descending,
                SortDirection.Descending => SortDirection.Ascending,
                _ => SortDirection.Ascending
            };
        }
    }

    public enum SortDirection
    {
        None,
        Ascending,
        Descending
    }
}
