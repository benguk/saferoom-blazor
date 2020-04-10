using System.Collections.Generic;
using SafeRoom.DAL.Entities;

namespace SafeRoom.DAL.Repositories
{
    public interface IChatroomRepository
    {
        IEnumerable<Chatroom> GetChatrooms();
        IEnumerable<Chatroom> GetChatroomsOfUser(int userId);
    }
}