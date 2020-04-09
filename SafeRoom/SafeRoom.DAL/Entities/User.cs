using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeRoom.DAL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserHash { get; set; }
    }
}
