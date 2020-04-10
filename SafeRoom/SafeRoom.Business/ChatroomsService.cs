using SafeRoom.Business.Entities;
using SafeRoom.Business.Extensions;
using SafeRoom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoom.Business
{
    public class ChatroomsService
    {
        private readonly ISafeRoomRepository _safeRoomRepository;

        public ChatroomsService(ISafeRoomRepository safeRoomRepository)
        {
            _safeRoomRepository = safeRoomRepository ?? throw new ArgumentNullException(nameof(safeRoomRepository)); ;
        }

        public IEnumerable<UserDto> GetChatrooms()
        {
            var users = _safeRoomRepository.GetUsers();
            var usersDto = users.Select(u => u.ToDto());
            return usersDto;
        }

        public IEnumerable<ChatroomDto> GetUserChatrooms(int userId)
        {
            var chatrooms = _safeRoomRepository.GetUserChatrooms(userId);
            var chatroomsDto = chatrooms.Select(c => c.ToDto());
            return chatroomsDto;
        }
    }
}
