using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.ImportFromXML
{
    class ImportFromXML
    {
        static void Main(string[] args)
        {
            var context = new FootballExamEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../leagues-and-teams.xml");

            var root = doc.DocumentElement;
            int id = 1;

            foreach (XmlNode xmlLeague in root.ChildNodes)
            {
                Console.WriteLine("Processing league #{0} ...", id++);
                XmlNode leagueNameNode = xmlLeague.SelectSingleNode("league-name");
                League league = null;

                if (leagueNameNode != null)
                {
                    string leagueName = leagueNameNode.InnerText;

                    league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                    if (league != null)
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                    else
                    {
                        league = new League()
                        {
                            LeagueName = leagueName
                        };

                        context.Leagues.Add(league);
                        Console.WriteLine("Creating league: {0}", leagueName);
                    }
                }

                XmlNode teamsNode = xmlLeague.SelectSingleNode("teams");
                if (teamsNode != null)
                {
                    foreach (XmlNode xmlTeam in teamsNode.ChildNodes)
                    {
                        Team team = null;
                        string teamName = xmlTeam.Attributes["name"].InnerText;
                        string countryName = "";

                        if (xmlTeam.Attributes["country"] != null)
                        {
                            countryName = xmlTeam.Attributes["country"].InnerText;
                        }

                        team = context.Teams.FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);

                        if (team != null)
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName, countryName ?? "no country");
                        }
                        else
                        {
                            Country country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                            team = new Team()
                            {
                                TeamName = teamName,
                                Country = country
                            };
                            context.Teams.Add(team);
                            Console.WriteLine("Created team: {0} ({1})", teamName, countryName ?? "no country");
                            
                        }

                        if (league != null)
                        {
                            if (league.Teams.Contains(team))
                            {
                                Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName, league.LeagueName);
                            }
                            else
                            {
                                league.Teams.Add(team);
                                Console.WriteLine("Added team to league: {0} to league {1}", teamName, league.LeagueName);
                            }  
                        }

                    }
                }
                context.SaveChanges();
            }
        }
    }
}
