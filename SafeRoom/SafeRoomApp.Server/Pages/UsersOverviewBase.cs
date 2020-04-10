using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SafeRoom.Business;
using SafeRoom.Business.Entities;
using SafeRoom.Business.Services;
using SafeRoom.DAL;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Server.Pages
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        [Inject]
        public ILogger<UsersOverviewBase> Logger { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Users = await UserDataService.GetUsers();
        }
    }
}
