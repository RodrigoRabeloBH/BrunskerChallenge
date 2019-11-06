using System;
using System.Linq;
using System.Threading.Tasks;
using BrunskerApi.Data;
using BrunskerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrunskerApi.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly BrunskerContext _context;

        public AuthServices(BrunskerContext context)
        {
            _context = context;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computeHash.Length; i++)
                {
                    if(computeHash[i] != passwordHash[i])return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[]passwordHash, out byte[]passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<User> Loging(string nickname, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
            if(user == null)
            {
                return null;
            }
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }  

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> UserExists(string nickname)
        {
            if(await _context.Users.AnyAsync(u => u.Nickname == nickname))
            {
                return true;
            }
            return false;
        }
    }
}