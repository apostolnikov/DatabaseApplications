using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _02.ExportLeaguesTeamsToJSON
{
    class ExportLeaguesTeamsToJSON
    {
        static void Main(string[] args)
        {
            var context = new FootballExamEntities();

            var leagues = context.Leagues.OrderBy(l => l.LeagueName).Select(l => new 
            { 
                leagueName = l.LeagueName,
                teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
            }).ToList();

            var json = new JavaScriptSerializer().Serialize(leagues);

            File.WriteAllText("../../leagues-and-teams.json", json);
           


            /*
            foreach (var league in leagues)
            {
                Console.WriteLine(league.Name);

                foreach (var teams in league.LeagueTeams)
                {
                    Console.WriteLine(teams);
                }
            }
            */
        }
    }
}
