using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06.ChatSystem_CodeFirst.Migrations;

namespace _06.ChatSystem_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatSystemContext, ChatSystemDatabaseMigrationConfigoration>());

            var context = new ChatSystemContext();

            Console.WriteLine(context.Channels.Count());

                 var channelMessage = context.Channels
                .Select(c => new
                {
                    ChannelName = c.Name,
                    Content = c.ChannelMessages.Select(cm => new
                    {
                        contentText = cm.Content,
                        dateTime = cm.DateTime,
                        user = cm.User.Username
                    })
                });

            foreach (var c in channelMessage)
            {
                Console.WriteLine(c.ChannelName);

                Console.WriteLine("-- Messages: --");

                foreach (var cont in c.Content)
                {
                    Console.WriteLine("Content: {0}, Datetime: {1}, User: {2}",cont.contentText, cont.dateTime, cont.user);
                }
            }

        }
    }
}
