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
    [Route("api/chatrooms")]
    [ApiController]
    public class ChatroomController : Controller
    {
        private readonly ILogger<ChatroomController> _logger;
        private readonly IChatroomRepository _chatroomRepository;

        public ChatroomController(IChatroomRepository chatroomRepository, ILogger<ChatroomController> logger)
        {
            _logger = logger;
            _chatroomRepository = chatroomRepository;
        }

        [HttpGet]
        public IActionResult GetChatrooms()
        {
            var chatrooms = _chatroomRepository.GetChatrooms().Select(c => c.ToDto());
            return Ok(chatrooms);
        }

        // Make sure the {} value matches with parameters
        [HttpGet("user/{userId}")]
        public IActionResult GetChatroomsOfUser(int userId)
        {
            var chatrooms = _chatroomRepository.GetChatroomsOfUser(userId).Select(c => c.ToDto());
            return Ok(chatrooms);
        }
    }
}
