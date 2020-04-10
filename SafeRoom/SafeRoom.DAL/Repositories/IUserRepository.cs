using System.Collections.Generic;
using SafeRoom.DAL.Entities;

namespace SafeRoom.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int userId);
        User GetUserByEmailAsync(string email);
        IEnumerable<User> GetUsers();
    }
}