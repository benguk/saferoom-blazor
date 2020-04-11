using System.Collections.Generic;
using System.Threading.Tasks;
using SafeRoom.Business.Models;

namespace SafeRoomApp.Core.Services
{
    public interface IChatroomDataService
    {
        Task<ChatroomDto> GetChatroomDetails(int chatroomId);
        Task<IEnumerable<ChatroomDto>> GetChatrooms();
        Task<IEnumerable<ChatroomDto>> GetChatroomsOfUser(int userId);
    }
}