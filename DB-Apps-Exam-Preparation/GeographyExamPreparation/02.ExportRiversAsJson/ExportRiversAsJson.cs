using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using _01.DatabaseFirst;

namespace _02.ExportRiversAsJson
{
    class ExportRiversAsJson
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName)

                }).ToList();

            var json = new JavaScriptSerializer().Serialize(rivers);
            File.WriteAllText("../../rivers.json", json);

        }
    }
}
