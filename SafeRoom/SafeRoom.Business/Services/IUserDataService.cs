﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SafeRoom.Business.Entities;

namespace SafeRoom.Business.Services
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