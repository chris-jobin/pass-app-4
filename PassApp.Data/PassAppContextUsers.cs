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

        public async Task<User> GetUser(string username, string password)
        {
            User user = null;
            try
            {
                var encryptedPassword = password; // TODO : password encryption
                user = await Users.SingleOrDefaultAsync(x =>
                        x.UserName == username &&
                        x.Password == encryptedPassword);
            }
            catch (Exception)
            {
            }
            return user;
        }
        public async Task<bool> Login(string username, string password)
        {
            try
            {
                var user = await GetUser(username, password);
                return user != null;
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
