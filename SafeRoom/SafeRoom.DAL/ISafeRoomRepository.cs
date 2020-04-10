using System.Collections.Generic;
using SafeRoom.DAL.Entities;

namespace SafeRoom.DAL
{
    public interface ISafeRoomRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        User GetUserByEmailAsync(string email);
        IEnumerable<Chatroom> GetChatrooms();
        IEnumerable<Chatroom> GetUserChatrooms(int userId);
    }
}