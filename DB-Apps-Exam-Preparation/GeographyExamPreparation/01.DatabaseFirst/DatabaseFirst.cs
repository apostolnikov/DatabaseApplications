using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var continentNames = context.Continents.Select(c => c.ContinentName);
            foreach (var cn in continentNames)
            {
                Console.WriteLine(cn);
            }
        }
    }
}
