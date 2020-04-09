using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.DAL.Entities
{
    public class Chatroom
    {
        public int ChatroomId { get; set; }
        public int OwnerId { get; set; }
        public string ChatroomName { get; set; }
        public string Status { get; set; }
    }
}
