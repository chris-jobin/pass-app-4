﻿using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PassApp.Data;
using PassApp.Web.Buttons;
using PassApp.Web.Form;
using PassApp.Web.Modal;
using PassApp.Web.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public PassAppContext? PassAppContext { get; set; }
        public TableModel? Table { get; set; }
        public Modal? ModalRef { get; set; }
        public ItemForm? FormRef { get; set; }
        public ItemFormModel? ItemForm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Table = await GetTable();
        }

        protected async Task<TableModel> GetTable()
        {
            return new TableModel
            {
                Headers = new List<TableHeaderModel>
                {
                    new TableHeaderModel { Name = "Category", Width = 10, Filter = TableHeaderModel.FilterType.DropDown },
                    new TableHeaderModel { Name = "Title", Width = 10, Filter = TableHeaderModel.FilterType.Text, Column = TableHeaderModel.ColumnType.Link },
                    new TableHeaderModel { Name = "Username", Width = 10, Filter = TableHeaderModel.FilterType.Text, Column = TableHeaderModel.ColumnType.Button },
                    new TableHeaderModel { Name = "Email", Width = 10, Filter = TableHeaderModel.FilterType.Text, Column = TableHeaderModel.ColumnType.Button },
                    new TableHeaderModel { Name = "Password", Width = 10, Column = TableHeaderModel.ColumnType.Password },
                    new TableHeaderModel { Name = "", Width = 1 }
                },
                StoredItems = await PassAppContext.Records.Select(x => new TableBodyModel
                {
                    Content = new List<TableCellModel>
                    {
                        new TableCellModel { Id = Guid.NewGuid().ToString(), Text = x.Category },
                        new TableCellModel { Id = Guid.NewGuid().ToString(), Text = x.Title, Link = x.Link },
                        new TableCellModel { Id = Guid.NewGuid().ToString(), Text = x.Username },
                        new TableCellModel { Id = Guid.NewGuid().ToString(), Text = x.Email },
                        new TableCellModel { Id = Guid.NewGuid().ToString(), Text = x.Password }
                    },
                    Buttons = new List<IconButtonModel>
                    {
                        new IconButtonModel { IconClass = "oi oi-pencil text-primary", IconText = "View", Parameters = new[] { "view", x.Id.ToString() } }
                    }
                }).ToListAsync(),
                FooterButtons = new List<IconButtonModel>
                {
                    new IconButtonModel { IconClass = "oi oi-plus text-success", IconText = "Add", Parameters = new[] { "add", Guid.NewGuid().ToString() } }
                },
                HasPaging = true,
                ItemsPerPage = 15
            };
        }

        protected async Task ListingAction(string[] args)
        {
            ItemForm = await PassAppContext.GetItemFormModel(args[1]);
            ModalRef?.Open();
        }

        protected async Task SaveItemForm()
        {
            if (FormRef.Context.IsValid() && await PassAppContext.SetItemFormModel(ItemForm))
            {
                ModalRef?.Close();
                Table = await GetTable();
            }
        }
    }
}