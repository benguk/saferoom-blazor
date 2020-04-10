using SafeRoom.Business.Models;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.Business.Extensions
{
    public static class UserExtension
    {
        public static UserDto ToDto(this User item)
        {
            return new UserDto()
            {
                UserId = item.UserId,
                Email = item.Email,
            };
        }
    }
}
