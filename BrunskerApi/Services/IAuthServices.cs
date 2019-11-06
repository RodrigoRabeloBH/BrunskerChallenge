using System.Threading.Tasks;
using BrunskerApi.Models;

namespace BrunskerApi.Services
{
    public interface IAuthServices
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string nickname, string password);
         Task<bool> UserExists(string nickname);
    }
}