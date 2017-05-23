using System.IO;
using Newtonsoft.Json.Linq;

namespace _05.Movie_Code_First.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MovieMigrationConfiguration : DbMigrationsConfiguration<_05.Movie_Code_First.MovieContext>
    {
        public MovieMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieContext context)
        {
            string countryJson = File.ReadAllText("../../countries.json");
            var countryToArray = JArray.Parse(countryJson);

            foreach (var c in countryToArray)
            {
                var country = c.First.First.ToString();

                var countries = new Country()
                {
                    Name = country
                };

                context.Countries.Add(countries);

                context.SaveChanges();

            }
        }
    }
}
