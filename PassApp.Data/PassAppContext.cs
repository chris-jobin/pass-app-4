using Microsoft.EntityFrameworkCore;
using System;

namespace PassApp.Data
{
    public partial class PassAppContext : DbContext
    {
        public PassAppContext(DbContextOptions<PassAppContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=passapp.db");
    }
}
