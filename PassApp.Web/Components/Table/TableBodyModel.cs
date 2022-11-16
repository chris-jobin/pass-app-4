﻿using PassApp.Web.Components.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Web.Components.Table
{
    public class TableBodyModel
    {
        public string? Id { get; set; }
        public List<TableCellModel>? Content { get; set; }
        public List<IconButtonModel>? Buttons { get; set; }
    }
}