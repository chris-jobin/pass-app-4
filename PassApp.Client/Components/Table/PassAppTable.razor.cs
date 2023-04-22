using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PassApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Table
{
    public partial class PassAppTable
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public List<Record> Records { get; set; }
        [Parameter]
        public List<string> Categories { get; set; }
        private List<Record> _Records { get; set; }
        private List<PassAppTableHeader> Headers { get; set; } = new();
        private List<PassAppTableFilter> Filters { get; set; } = new();
        private int ItemsPerPage { get; set; } = 10;
        private int CurrentPage { get; set; } = 1;
        private int NumberOfPages => ((_Records.Count - 1) / ItemsPerPage) + 1;
        private List<Record> PagedRecords => _Records?.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();

        protected override async Task OnParametersSetAsync()
        {
            _Records = Records;
            await Task.Yield();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Js.InvokeVoidAsync("SetResize", DotNetObjectReference.Create(this));
                await Js.InvokeVoidAsync("UpdateItemsPerPage", DotNetObjectReference.Create(this));
            }
        }

        public void AddHeader(PassAppTableHeader header)
        {
            Headers.Add(header);
            StateHasChanged();
        }

        public void AddFilter(PassAppTableFilter filter) 
        { 
            Filters.Add(filter);
        }

        private void OnFilter()
        {
            _Records = Filter();
            _Records = CurrentSort();
        }

        private List<Record> Filter()
        {
            var records = new List<Record>();
            records.AddRange(Records);
            var filters = Filters.Where(x => !string.IsNullOrEmpty(x.FilterText)).ToList();
            foreach (var filter in filters)
            {
                var filterdItems = Records.Where(x =>
                    string.IsNullOrEmpty(x.GetPropertyValue(filter.Property)) ||
                    !x.GetPropertyValue(filter.Property).ToLower().Contains(filter.FilterText.ToLower()))
                    .ToList();
                foreach (var item in filterdItems)
                {
                    records.Remove(item);
                }
            }
            return records;
        }

        private void OnSort(PassAppTableHeader header)
        {
            _Records = Sort(header, true);
        }

        private List<Record> Sort(PassAppTableHeader header, bool changeSort)
        {
            var parameter = Expression.Parameter(typeof(Record));
            var property = Expression.Property(parameter, header.Property);
            var propObject = Expression.Convert(property, typeof(object));
            var expression = Expression.Lambda<Func<Record, object>>(propObject, parameter);
            ClearSort(header);
            if (changeSort)
                header.SetNextSort();
            var records = header.Direction switch
            {
                SortDirection.Ascending => _Records.AsQueryable().OrderBy(expression).ToList(),
                SortDirection.Descending => _Records.AsQueryable().OrderByDescending(expression).ToList(),
                _ => _Records
            };
            return records;
        }

        private List<Record> CurrentSort()
        {
            var currentSort = Headers.SingleOrDefault(x => x.Direction != SortDirection.None);
            if (currentSort != null)
                return Sort(currentSort, false);
            return _Records;
        }

        private void ClearSort(PassAppTableHeader header)
        {
            var sortedHeader = Headers.SingleOrDefault(x => x != header && x.Direction != SortDirection.None);
            if (sortedHeader != null)
                sortedHeader.Direction = SortDirection.None;
        }

        [JSInvokable("UpdateItemsPerPage")]
        public async Task UpdateItemsPerPage(int itemsPerPage)
        {
            if (ItemsPerPage != itemsPerPage)
            {
                ItemsPerPage = itemsPerPage;
                if (CurrentPage > NumberOfPages)
                    ChangePage(NumberOfPages);
                StateHasChanged();
            }
            await Task.Yield();
        }

        private void ChangePage(int page)
        {
            if (page > 0 && page <= NumberOfPages)
                CurrentPage = page;
        }
    }
}
