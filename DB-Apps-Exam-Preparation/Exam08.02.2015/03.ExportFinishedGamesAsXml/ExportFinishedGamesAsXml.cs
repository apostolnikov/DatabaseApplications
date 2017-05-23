namespace _03.ExportFinishedGamesAsXml
{
    using System.Linq;
    using _01.DatabaseFirst;
    using System.Xml.Linq;

    class ExportFinishedGamesAsXml
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var finishedGames = context.Games
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new
                {
                    GameName = g.Name,
                    GameDuration = g.Duration,
                    User = g.UsersGames.Select(ug => new
                    {
                        username = ug.User.Username,
                        ip = ug.User.IpAddress
                    })
                }).ToList();

            XElement games = new XElement("games");

            foreach (var game in finishedGames)
            {
                var gameXml = new XElement("game", new XAttribute("name", game.GameName));
                if (game.GameDuration != null)
                {
                    gameXml.Add(new XAttribute("duration", game.GameDuration));
                }

                var usersXml = new XElement("users");

                foreach (var user in game.User)
                {
                    var currentUserXml = new XElement("user", new XAttribute("username", user.username));
                    currentUserXml.Add(new XAttribute("ip-address", user.ip));
                    usersXml.Add(currentUserXml);
                }

                gameXml.Add(usersXml);

                games.Add(gameXml);
            }

            //Console.WriteLine(games);

            games.Save("../../finished-games.xml");
        }
    }
}
