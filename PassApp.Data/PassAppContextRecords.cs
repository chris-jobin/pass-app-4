using Microsoft.EntityFrameworkCore;
using PassApp.Data.Models;
using PassApp.Web.Form;
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

        private async Task<List<string>> GetDistinctCategories() => await Records.Select(x => x.Category).Distinct().ToListAsync();

        public async Task<ItemFormModel> GetItemFormModel(string id)
        {
            var record = await Records.SingleOrDefaultAsync(x => x.Id.ToString() == id);

            return new ItemFormModel
            {
                Id = record?.Id ?? Guid.Parse(id),
                Categories = await GetDistinctCategories(),
                Category = record?.Category,
                Title = record?.Title,
                Link = record?.Link,
                Username = record?.Username,
                Email = record?.Email,
                Password = record?.Password,
                Notes = record?.Notes
            };
        }

        public async Task<bool> SetItemFormModel(ItemFormModel model)
        {
            try
            {
                var record = await Records.FindAsync(model.Id);

                if (record == null)
                {
                    record = new Record
                    {
                        Id = model.Id,
                        Created = DateTime.Now,
                    };
                    await Records.AddAsync(record);
                }

                record.Category = model.Category;
                record.Title = model.Title;
                record.Link = model.Link;
                record.Email = model.Email;
                record.Username = model.Username;
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

        public async Task<bool> DeleteRecord(string id)
        {
            try
            {
                var record = await Records.FindAsync(Guid.Parse(id));

                if (record != null)
                {
                    Records.Remove(record);
                    await SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
