using SafeRoom.Business.Entities;
using SafeRoom.Business.Extensions;
using SafeRoom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoom.Business
{
    public class UsersService
    {
        private readonly ISafeRoomRepository _safeRoomRepository;

        public UsersService(ISafeRoomRepository safeRoomRepository)
        {
            _safeRoomRepository = safeRoomRepository ?? throw new ArgumentNullException(nameof(safeRoomRepository)); ;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _safeRoomRepository.GetUsers();
            var usersDto = users.Select(u => u.ToDto());
            return usersDto;
        }

        public UserDto GetUser(int userId)
        {
            var user = _safeRoomRepository.GetUser(userId);
            var userDto = user.ToDto();
            return userDto;
        }
    }
}
