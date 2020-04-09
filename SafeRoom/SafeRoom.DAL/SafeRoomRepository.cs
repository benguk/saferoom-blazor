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

        public async Task<IList<User>> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            IQueryable<User> dbQuery = _context.Set<User>();
            return await dbQuery.Where(a => a.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync();
        }

        public async Task<IList<User>> GetUsersAsync(int page, int limit)
        {
            if (page == 0)
            {
                page = 1;
            }

            if (limit == 0)
            {
                limit = int.MaxValue;
            }

            var skip = (page - 1) * limit;

            IQueryable<User> dbQuery = _context.Set<User>();
            return await dbQuery.Skip(skip).Take(limit).ToListAsync();
        }
    }
}
