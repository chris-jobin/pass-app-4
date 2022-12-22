using Microsoft.EntityFrameworkCore;
using PassApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Data
{
    public partial class PassAppContext
    {
        public DbSet<Record> Records { get; set; }
    }
}
