using SafeRoom.DAL;
using System;

namespace SafeRoom.Business
{
    public class UsersService
    {
        private readonly SafeRoomRepository _safeRoomRepository;

        public UsersService(SafeRoomRepository safeRoomRepository)
        {
            _safeRoomRepository = safeRoomRepository ?? throw new ArgumentNullException(nameof(safeRoomRepository)); ;
        }

        public void GetUsers()
        {
            var test = _safeRoomRepository.GetUsersAsync("yo").Result;
        }
    }
}
