namespace _02.CharactersAndPlayersAsJson
{
    using System;
    using System.Linq;
    using _01.DatabaseFirst;
    using System.Web.Script.Serialization;
    using System.IO;

    class CharactersAndPlayersAsJson
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var characters = context.Characters
                .OrderBy(ch => ch.Name)
                .Select(ch => new
                {
                    name = ch.Name,
                    playedBy = ch.UsersGames.Select(u => u.User.Username)
                }).ToList();

            var json = new JavaScriptSerializer().Serialize(characters);
            
            //Console.WriteLine(json);

            File.WriteAllText("../../characters.json", json);

        }
    }
}
