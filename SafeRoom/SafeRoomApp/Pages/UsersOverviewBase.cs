using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using SafeRoom.Business;
using SafeRoom.Business.Entities;
using SafeRoom.DAL;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Pages
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        protected UsersService UsersService { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

        protected override Task OnInitializedAsync()
        {
            Users = UsersService.GetUsersAsync().Result;
            return base.OnInitializedAsync();
        }
    }
}
