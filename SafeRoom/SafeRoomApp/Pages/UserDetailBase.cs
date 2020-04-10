using Microsoft.AspNetCore.Components;
using SafeRoom.Business;
using SafeRoom.Business.Entities;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Pages
{
    public class UserDetailBase : ComponentBase
    {
        [Inject]
        protected ChatroomsService ChatroomsService { get; set;}
        [Inject]
        protected UsersService UsersService { get; set; }

        [Parameter]
        public string UserId { get; set; }

        public UserDto User { get; set; } = new UserDto();
        public IEnumerable<ChatroomDto> Chatrooms { get; set; }

        protected override Task OnInitializedAsync()
        {
            var userId = int.Parse(UserId);
            User = UsersService.GetUser(userId);
            Chatrooms = ChatroomsService.GetUserChatrooms(userId);
            return base.OnInitializedAsync();
        }
    }
}
