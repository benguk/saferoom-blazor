using System.Collections.Generic;
using System.Threading.Tasks;
using SafeRoom.Business.Models;

namespace SafeRoom.Business.Services
{
    public interface IChatroomDataService
    {
        Task<ChatroomDto> GetChatroomDetails(int chatroomId);
        Task<IEnumerable<ChatroomDto>> GetChatrooms();
        Task<IEnumerable<ChatroomDto>> GetChatroomsOfUser(int userId);
    }
}