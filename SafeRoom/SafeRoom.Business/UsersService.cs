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
        private readonly SafeRoomRepository _safeRoomRepository;

        public UsersService(SafeRoomRepository safeRoomRepository)
        {
            _safeRoomRepository = safeRoomRepository ?? throw new ArgumentNullException(nameof(safeRoomRepository)); ;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(int page = 0, int limit = 0)
        {
            var users = await _safeRoomRepository.GetUsersAsync(page, limit);
            var usersDto = users.Select(u => u.ToDto());
            return usersDto;
        }
    }
}
