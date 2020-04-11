using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.Business.Models
{
    public class ChatroomDto
    {
        public int ChatroomId { get; set; }
        public int OwnerId { get; set; }
        public string ChatroomName { get; set; }
        public string Status { get; set; }
    }
}
