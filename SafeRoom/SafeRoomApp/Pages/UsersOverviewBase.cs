using Microsoft.AspNetCore.Components;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoomApp.Pages
{
    public class UsersOverviewBase : ComponentBase
    {
        public IEnumerable<User> Users { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeUsers();
            return base.OnInitializedAsync();
        }

        private void InitializeUsers()
        {
            Users = new List<User>()
            {
                new User(){ UserId = 1, UserHash = "hash01" },
                new User(){ UserId = 2, UserHash = "hash02" },
            };
        }
    }
}
