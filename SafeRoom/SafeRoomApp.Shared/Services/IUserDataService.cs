using System.Collections.Generic;
using System.Threading.Tasks;
using SafeRoom.Business.Models;

namespace SafeRoomApp.Shared.Services
{
    public interface IUserDataService
    {
        Task<UserDto> AddUser(UserDto user);
        Task DeleteUser(int userId);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int userId);
        Task UpdateUser(UserDto user);
    }
}