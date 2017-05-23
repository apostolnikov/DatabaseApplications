namespace _06.ChatSystem_CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatSystemContext : DbContext
    {

        public ChatSystemContext()
            : base("name=ChatSystemContext")
        {
        }


        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Channel> Channels { get; set; }

        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }
    }


}