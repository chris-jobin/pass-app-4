using Microsoft.EntityFrameworkCore;
using System;

namespace PassApp.Data
{
    public partial class PassAppContext : DbContext
    {
        private static bool Created { get; set; }

        public PassAppContext(DbContextOptions<PassAppContext> options) : base(options) 
        {
            if (!Created)
            {
                Database.EnsureCreated();
                Created = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=passapp.db");
    }
}
