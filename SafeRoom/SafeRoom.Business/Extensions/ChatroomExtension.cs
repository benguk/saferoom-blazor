using SafeRoom.Business.Entities;
using SafeRoom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.Business.Extensions
{
    public static class ChatroomExtension
    {
        public static ChatroomDto ToDto(this Chatroom item)
        {
            return new ChatroomDto()
            {
                ChatroomId = item.ChatroomId,
                ChatroomName = item.ChatroomName,
                OwnerId = item.OwnerId,
                Status = item.Status,
            };
        }
    }
}
