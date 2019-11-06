using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrunskerApi.Data;
using BrunskerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrunskerApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly BrunskerContext _context;

        public UserServices(BrunskerContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var user = GetById(id);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}