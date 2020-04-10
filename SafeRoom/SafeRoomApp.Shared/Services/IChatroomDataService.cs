using System.Collections.Generic;
using System.Threading.Tasks;
using SafeRoom.Business.Models;

namespace SafeRoomApp.Shared.Services
{
    public interface IChatroomDataService
    {
        Task<ChatroomDto> GetChatroomDetails(int chatroomId);
        Task<IEnumerable<ChatroomDto>> GetChatrooms();
        Task<IEnumerable<ChatroomDto>> GetChatroomsOfUser(int userId);
    }
}