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
            Database.EnsureCreated();
        }

        // TODO: Remove. This is for testing and creating the initial DB
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        // TODO: Remove
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SafeRoomDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            builder.Entity<User>().HasData(
              new User { UserId = 1, Email = "Email01@test.com" },
              new User { UserId = 2, Email = "Email02@test.com" }
            );
            builder.Entity<Chatroom>().HasData(
              new Chatroom { ChatroomId = 1, ChatroomName = "Chatroom Name 01", OwnerId = 1, Status = "Closed" },
              new Chatroom { ChatroomId = 2, ChatroomName = "Chatroom Name 02", OwnerId = 1, Status = "Open" }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole{ get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }   
    }
}
