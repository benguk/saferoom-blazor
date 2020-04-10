using Microsoft.EntityFrameworkCore;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeRoom.DAL.Repositories
{
    public class ChatroomRepository : IChatroomRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatroomRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.Database.SetCommandTimeout(3600);
        }

        public IEnumerable<Chatroom> GetChatroomsOfUser(int userId)
        {
            var chatrooms = _context.Chatrooms
                .Where(c => c.OwnerId.Equals(userId))
                .ToList();

            return chatrooms;
        }

        public IEnumerable<Chatroom> GetChatrooms()
        {
            return _context.Chatrooms.OrderBy(c => c.OwnerId).OrderBy(c => c.ChatroomName).ToList();
        }
    }
}
