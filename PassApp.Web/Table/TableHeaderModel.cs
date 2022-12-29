using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Table
{
    public class TableHeaderModel
    {
        public string? Name { get; set; }
        public int Width { get; set; }
        public string ColumnWidth => $"{Width}vw";
        public SortDirection Direction { get; set; }
        public ColumnType Column { get; set; }
        public FilterType Filter { get; set; }
        public string? FilterText { get; set; }

        public void SetNextSortDirection()
        {
            var directions = (SortDirection[])Enum.GetValues(typeof(SortDirection));
            var index = Array.IndexOf(directions, Direction) + 1;
            Direction = index == directions.Length ? directions[0] : directions[index];
        }

        public enum SortDirection
        {
            None,
            Ascending,
            Descending
        }

        public enum ColumnType
        {
            None,
            Link,
            Button,
            Password
        }

        public enum FilterType
        {
            None,
            Text,
            DropDown
        }
    }
}
