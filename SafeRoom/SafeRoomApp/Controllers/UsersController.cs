using Microsoft.AspNetCore.Mvc;
using SafeRoom.Business;
using SafeRoom.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _usersService.GetUsersAsync();
            return users;
        }
    }
}
