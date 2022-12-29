using PassApp.Web.Buttons;
using PassApp.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Table
{
    public class TableModel
    {
        public List<TableHeaderModel>? Headers { get; set; }
        public List<TableBodyModel>? StoredItems { get; set; }
        public List<IconButtonModel>? FooterButtons { get; set; }
        public bool HasPaging { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int NumberOfPages => (((DisplayItems?.Count + ItemsPerPage - 1) / ItemsPerPage) ?? 1) == 0 ? 1 : ((DisplayItems?.Count + ItemsPerPage - 1) / ItemsPerPage) ?? 1;
        public List<TableBodyModel>? DisplayItems { get; set; }
        public List<TableBodyModel>? PagedItems => DisplayItems?.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();
        public List<TableBodyModel>? Items => HasPaging ? PagedItems : DisplayItems;

        public void Sort(int index)
        {
            var header = Headers?[index];
            if (header == null)
                return;

            header.SetNextSortDirection();

            SortHeader(header, index);

            var otherHeaders = Headers?.Where(x => x != header && x.Direction != TableHeaderModel.SortDirection.None).ToList();
            otherHeaders?.ForEach(x => x.Direction = TableHeaderModel.SortDirection.None);
        }

        public void SortHeader(TableHeaderModel header, int index)
        {
            if (header.Direction == TableHeaderModel.SortDirection.Ascending)
                DisplayItems = DisplayItems?.OrderBy(x => x.Content?[index]?.Text).ToList();
            else if (header.Direction == TableHeaderModel.SortDirection.Descending)
                DisplayItems = DisplayItems?.OrderByDescending(x => x.Content?[index]?.Text).ToList();
            else
                DisplayItems = StoredItems?.Intersect(DisplayItems ?? Enumerable.Empty<TableBodyModel>()).ToList();
        }

        public void Filter(int index, string? filterText)
        {
            var sortedHeader = Headers?.SingleOrDefault(x => x.Direction != TableHeaderModel.SortDirection.None);
            if (sortedHeader != null)
                sortedHeader.Direction = TableHeaderModel.SortDirection.None;

            var header = Headers?[index];

            if (header == null)
                return;

            header.FilterText = filterText;

            var filteredItems = new List<TableBodyModel>();
            filteredItems.AddRange(StoredItems ?? Enumerable.Empty<TableBodyModel>());

            for (int i = 0; i < Headers?.Count; i++)
            {
                if (!string.IsNullOrEmpty(Headers[i].FilterText))
                {
                    for (int j = 0; j < (filteredItems?.Count ?? 0); j++)
                    {
                        var description = filteredItems?[j]?.Content?[i]?.Text?.Trim()?.ToLower();
                        var headerFilterText = Headers[i]?.FilterText?.ToLower();

                        if ((string.IsNullOrEmpty(description) || string.IsNullOrEmpty(headerFilterText)) ||
                            (Headers[i].Filter == TableHeaderModel.FilterType.Text && !description.Contains(headerFilterText)) ||
                            Headers[i].Filter == TableHeaderModel.FilterType.DropDown && description != headerFilterText)
                        {
                            filteredItems?.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(header.FilterText)) 
                filteredItems = filteredItems?.OrderByDescending(x => x.Content[index]?.Text?.ToLower()?.StartsWith(header.FilterText.ToLower())).ToList();

            DisplayItems = filteredItems;

            if (CurrentPage > NumberOfPages)
                ChangePage(NumberOfPages);
        }

        public List<string>? GetColumnItems(int index)
        {
            var columnItems = StoredItems?
                .Where(x => !string.IsNullOrEmpty(x.Content?[index].Text))
                .Select(x => x.Content?[index].Text)
                .Distinct()
                .Order()
                .ToList();
            return columnItems?.ToList();
        }

        public void ChangePage(int page)
        {
            CurrentPage = page;
        }
    }
}
