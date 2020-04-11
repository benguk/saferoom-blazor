using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SafeRoom.Business.Models;
using SafeRoomApp.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeRoomApp.Core.Pages
{
    public class UserDetailBase : ComponentBase
    {
        [Inject]
        protected IChatroomDataService ChatroomDataService { get; set;}
        [Inject]
        protected IUserDataService UserDataService { get; set; }

        //[Inject]
        //protected ILogger<UserDetailBase> Logger { get; set; }

        [Parameter]
        public string UserId { get; set; }

        public UserDto User { get; set; } = new UserDto();
        public IEnumerable<ChatroomDto> Chatrooms { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = int.Parse(UserId);
            User = await UserDataService.GetUser(userId);
            Chatrooms = await ChatroomDataService.GetChatroomsOfUser(userId);
        }
    }
}
