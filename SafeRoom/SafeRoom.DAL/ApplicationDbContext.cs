using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
 
        public DbSet<User> Users { get; set; }

    }
}
