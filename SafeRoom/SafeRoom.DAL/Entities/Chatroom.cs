using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeRoom.DAL.Entities
{
    public class Chatroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatroomId { get; set; }
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(128)]
        public string ChatroomName { get; set; }
        [Required]
        [MaxLength(64)] 
        public string Status { get; set; }
    }
}
