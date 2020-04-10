using Microsoft.EntityFrameworkCore;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // TODO: Remove // For testing purpose and create DB when running if not using Migration
        /*
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SafeRoomDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        */

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
              new User { UserId = 1, Email = "kenny@test.com" },
              new User { UserId = 2, Email = "Email02@test.com" },
              new User { UserId = 3, Email = "Email03@test.com" }
            );
            builder.Entity<Chatroom>().HasData(
              new Chatroom { ChatroomId = 1, OwnerId = 1, ChatroomName = "Chatroom Name 01", Status = "Closed" },
              new Chatroom { ChatroomId = 2, OwnerId = 1, ChatroomName = "Chatroom Name 02", Status = "Open" },
              new Chatroom { ChatroomId = 3, OwnerId = 2, ChatroomName = "Chatroom Name 03", Status = "Closed" },
              new Chatroom { ChatroomId = 4, OwnerId = 3, ChatroomName = "Chatroom Name 04", Status = "Closed" }
            );
            builder.Entity<Role>().HasData(
              new Role { RoleId = 1, RoleName = "admin" },
              new Role { RoleId = 2, RoleName = "moderator" }
            );
            builder.Entity<UserRole>().HasData(
              new UserRole { UserId = 1, RoleId = 1 },
              new UserRole { UserId = 2, RoleId = 2 }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole{ get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }   
    }
}
