using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeRoom.DAL.Entities
{
    public class UserRole
    {
        [ForeignKey("UserId")]
        public User User{ get; set; }
        public int UserId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public int RoleId{ get; set; }
    }
}
