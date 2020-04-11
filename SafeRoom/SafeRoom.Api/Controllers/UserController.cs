using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeRoom.Api.Extensions;
using SafeRoom.Business;
using SafeRoom.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoom.Api.Controllers
{
    // If you want to do versioning: https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            // If properties to exclude, can be done with DTO
            var users = _userRepository.GetUsers().Select(u => u.ToDto());
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetUser(userId).ToDto();
            return Ok(user);
        }
    }
}
