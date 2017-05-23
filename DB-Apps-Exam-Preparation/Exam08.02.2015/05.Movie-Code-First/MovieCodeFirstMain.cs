using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using _05.Movie_Code_First.Migrations;

namespace _05.Movie_Code_First
{
    internal class MovieCodeFirstMain
    {
        private static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieContext, MovieMigrationConfiguration>());
            var context = new MovieContext();
            Console.WriteLine(context.Countries.Count());

            //var json = File.ReadAllText(@"..\..\countries.json");
            //var jsSerializer = new JavaScriptSerializer();
            //var parsedMessages = jsSerializer.Deserialize<IEnumerable<UserDTO>>(json);

        //private static void ImportMessageToDatabase(CountryDTO message)
        //{


        //    var context = new MovieContext();


        //    var newCountry = new Country()
        //    {
        //        Name = "Ebasimo"
        //    };

        //    context.Countries.Add(newCountry);
        //    context.SaveChanges();
        //}







        }
    }

}