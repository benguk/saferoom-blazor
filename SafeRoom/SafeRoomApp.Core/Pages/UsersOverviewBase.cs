﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SafeRoom.Business.Models;
using SafeRoomApp.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeRoomApp.Core.Pages
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        //[Inject]
        //public ILogger<UsersOverviewBase> Logger { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Users = await UserDataService.GetUsers();
        }
    }
}
