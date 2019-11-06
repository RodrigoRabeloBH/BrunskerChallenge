using System.Collections.Generic;
using System.Threading.Tasks;
using BrunskerApi.Models;

namespace BrunskerApi.Services
{
    public interface IUserServices
    {
        Task Add(User user);
        Task Update(User user);
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();        
        Task Delete(int id);
    }
}