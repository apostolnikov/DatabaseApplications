using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _06.ChatSystem_CodeFirst
{
    public class ChannelMessage
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
