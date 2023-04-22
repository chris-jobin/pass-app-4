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

        public async Task<Record> GetRecord(Guid id) => await Records.FindAsync(id);
        public async Task<List<string>> GetDistinctCategories() => await Records.Select(x => x.Category).Distinct().ToListAsync();
        public async Task<bool> SetRecord(Record model)
        {
            try
            {
                var record = await GetRecord(model.Id);
                if (record == null)
                {
                    record = new Record
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now
                    };
                    await Records.AddAsync(record);
                }
                record.Category = model.Category;
                record.Title = model.Title;
                record.Link = model.Link;
                record.Username = model.Username;
                record.Email = model.Email;
                record.Password = model.Password;
                record.Notes = model.Notes;
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
