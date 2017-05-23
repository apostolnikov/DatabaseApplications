using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseFirst;
using System.Xml.Linq;

namespace _03.ExportMonasteriesXml
{
    class ExportMonasteriesXml
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var countries = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    countryName = c.CountryName,
                    monasteryName = c.Monasteries.OrderBy(m => m.Name).Select(m => m.Name)
                }).ToList();

            XElement monasteriesXml = new XElement("monasteries");

            foreach (var country in countries)
            {
                XElement countryXml = new XElement("country", new XAttribute("name", country.countryName));
                foreach (var monastery in country.monasteryName)
                {
                    var monasteryXml = new XElement("monastery", monastery);
                    countryXml.Add(monasteryXml);
                }
                monasteriesXml.Add(countryXml);
            }

            //Console.WriteLine(monasteriesXml.ToString());
            monasteriesXml.Save("../../monasteries.xml ");

        }
    }
}
