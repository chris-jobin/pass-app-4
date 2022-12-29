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
        public DbSet<User> Users { get; set; }

        public async Task<bool> Login(string username, string password)
        {
            try
            {
                var user = await Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
                return user != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Register(string username, string password)
        {
            try
            {
                if (await Users.AnyAsync())
                    return false;

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Created= DateTime.Now,
                    UserName = username,
                    Password = password
                };
                await Users.AddAsync(user);
                await SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser()
        {
            try
            {
                var user = await Users.FirstAsync();
                var records = await Records.ToListAsync();

                Users.Remove(user);
                Records.RemoveRange(records);
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
