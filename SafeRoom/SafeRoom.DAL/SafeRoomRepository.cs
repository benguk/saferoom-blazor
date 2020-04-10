using Microsoft.EntityFrameworkCore;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeRoom.DAL
{
    public class SafeRoomRepository : ISafeRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public SafeRoomRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.Database.SetCommandTimeout(3600);
        }

        public User GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var user = _context.Users
                .Where(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            return user;
        }

        public User GetUser(int userId)
        {
            var user = _context.Users
                .Where(u => u.UserId.Equals(userId))
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Email).ToList();
        }

        public IEnumerable<Chatroom> GetUserChatrooms(int userId)
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
