using Microsoft.EntityFrameworkCore;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeRoom.DAL
{
    public class SafeRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public SafeRoomRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.Database.SetCommandTimeout(3600);
        }

        public async Task<IList<User>> GetUsersAsync(string userHash)
        {
            if (string.IsNullOrWhiteSpace(userHash))
            {
                throw new ArgumentNullException(nameof(userHash));
            }

            return null;
        }
    }
}
