namespace _06.ChatSystem_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ChatSystemDatabaseMigrationConfigoration : DbMigrationsConfiguration<_06.ChatSystem_CodeFirst.ChatSystemContext>
    {
        public ChatSystemDatabaseMigrationConfigoration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_06.ChatSystem_CodeFirst.ChatSystemContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatSystemContext context)
        {
            if (!context.Database.Exists())
            {
            var vGeorgiev = new User()
                {
                    Username = "vGeorgiev",
                    FullName = "Vladimir Georgiev",
                    PhoneNumber = "089454848"
                };
                context.Users.Add(vGeorgiev);

                var Nakov = new User()
                {
                    Username = "Nakov",
                    FullName = "Svetlin Nakov",
                    PhoneNumber = "089454848"
                };
                context.Users.Add(Nakov);

                var Ache = new User()
                {
                    Username = "Ache",
                    FullName = "Angel Georgiev",
                    PhoneNumber = "089454848"
                };
                context.Users.Add(Ache);

                var Alex = new User()
                {
                    Username = "Alex",
                    FullName = "Alexandra Svilarova",
                    PhoneNumber = "089454848"
                };
                context.Users.Add(Alex);

                var Petya = new User()
                {
                    Username = "Petya",
                    FullName = "Petya Grozdarska",
                    PhoneNumber = "089454848"
                };
                context.Users.Add(Petya);

                var Malinki = new Channel()
                {
                    Name = "Malinki"
                };
                context.Channels.Add(Malinki);

                var Softuni = new Channel()
                {
                    Name = "Softuni"
                };
                context.Channels.Add(Softuni);

                var Admins = new Channel()
                {
                    Name = "Admins"
                };
                context.Channels.Add(Admins);

                var Programmers = new Channel()
                {
                    Name = "Programmers"
                };
                context.Channels.Add(Programmers);

                var Geeks = new Channel()
                {
                    Name = "Geeks"
                };
                context.Channels.Add(Geeks);

                var ChannelMessage1 = new ChannelMessage()
                {
                    Channel = Malinki,
                    Content = "Hey dudes, are you ready for tonight?",
                    DateTime = DateTime.Now,
                    User = Petya
                };
                context.ChannelMessages.Add(ChannelMessage1);

                var ChannelMessage2 = new ChannelMessage()
                {
                    Channel = Malinki,
                    Content = "Hey Petya, this is the SoftUni chat.",
                    DateTime = DateTime.Now,
                    User = vGeorgiev
                };
                context.ChannelMessages.Add(ChannelMessage2);


                var ChannelMessage3 = new ChannelMessage()
                {
                    Channel = Malinki,
                    Content = "Hahaha, we are ready.",
                    DateTime = DateTime.Now,
                    User = Nakov
                };
                context.ChannelMessages.Add(ChannelMessage3);


                var ChannelMessage4 = new ChannelMessage()
                {
                    Channel = Malinki,
                    Content = "Oh my god. I mean for drinking beers!",
                    DateTime = DateTime.Now,
                    User = Petya
                };
                context.ChannelMessages.Add(ChannelMessage4);


                var ChannelMessage5 = new ChannelMessage()
                {
                    Channel = Malinki,
                    Content = "Oh my god. I mean for drinking beers!",
                    DateTime = DateTime.Now,
                    User = vGeorgiev
                };
                context.ChannelMessages.Add(ChannelMessage5);

                context.SaveChanges();
            }
          

        }
    }
}
