using Microsoft.AspNetCore.Components;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Pages
{
    public class UserDetailBase : ComponentBase
    {
        [Parameter]
        public string UserId { get; set; }

        public User User { get; set; } = new User();
        public IEnumerable<Chatroom> Chatrooms { get; set; }

        // TODO: Remove Users...
        public IEnumerable<User> Users { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeUsers();
            InitializeChatrooms();
            User = Users.FirstOrDefault(u => u.UserId == int.Parse(UserId));
            return base.OnInitializedAsync();
        }

        // TODO: Remove and fetch from DB instead or local storage...
        private void InitializeUsers()
        {
            Users = new List<User>()
            {
                new User(){ UserId = 1, Email = "hash01" },
                new User(){ UserId = 2, Email = "hash02" },
            };
        }
        private void InitializeChatrooms()
        {
            Chatrooms = new List<Chatroom>()
            {
                new Chatroom(){ ChatroomId = 1, OwnerId = 1, ChatroomName = "Discussion about potatoes", Status = "Expired" },
                new Chatroom(){ ChatroomId = 2, OwnerId = 1, ChatroomName = "Let's talk about cheese", Status = "Open" },
            };
        }
    }
}
