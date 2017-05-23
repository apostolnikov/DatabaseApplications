using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03.ExportInternationalXML
{
    class ExportInternationalXML
    {
        static void Main(string[] args)
        {
            var context = new FootballExamEntities();
            var internationalMatches = context.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.CountryHome.CountryName)
                .ThenBy(im => im.CountryAway.CountryName)
                .Select(im => new
                {
                    HomeScore = im.HomeGoals,
                    AwayScore = im.AwayGoals,
                    HomeCodeCountry = im.HomeCountryCode,
                    AwayCodeCountry = im.AwayCountryCode,
                    Date = im.MatchDate,
                    HomeCountryName = im.CountryHome.CountryName,
                    AwayCountryName = im.CountryAway.CountryName,
                    MatchLeagueName = im.League.LeagueName
                }).ToList();

            XElement matches = new XElement("matches");

            foreach (var match in internationalMatches)
            {
                XElement xmlMatch = new XElement("match",
                        new XElement("home-country", new XAttribute("code", match.HomeCodeCountry), match.HomeCountryName),
                        new XElement("away-country", new XAttribute("code", match.AwayCodeCountry), match.AwayCountryName)
                    );

                if (match.MatchLeagueName != null)
                {
                    xmlMatch.Add(new XElement("league",match.MatchLeagueName));
                }

                if (match.HomeScore != null && match.AwayScore != null)
                {
                    xmlMatch.Add(new XElement("score",match.HomeScore + "-" + match.AwayScore));
                }

                if (match.Date != null)
                {
                    DateTime dateTime;
                    DateTime.TryParse(match.Date.ToString(), out dateTime);

                    if (dateTime.TimeOfDay.TotalSeconds == 0)
                    {
                        xmlMatch.Add(new XAttribute("date", dateTime.Day + "-" + dateTime.ToString("MMM") + "-" + dateTime.Year));    // ili dateTime.toString("dd-MMM-yyyy");
                    }
                    else if (dateTime.TimeOfDay.TotalSeconds != 0)
                    {
                        xmlMatch.Add(new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy hh:mm")));  // s dateTime.Minute dostupvam minutite  dateTIme.Hour dostupvam chasovete
                    }
                }

                matches.Add(xmlMatch);
            }


            //Console.WriteLine(matches.ToString());

            matches.Save("../../international-matches.xml");
         
        }
    }
}
