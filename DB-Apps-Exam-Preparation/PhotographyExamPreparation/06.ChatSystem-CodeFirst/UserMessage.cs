using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _06.ChatSystem_CodeFirst
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
