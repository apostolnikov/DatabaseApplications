using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _06.ChatSystem_CodeFirst
{
    public class User
    {

        public User()
        {
            this.Channels = new HashSet<Channel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }



    }
}
