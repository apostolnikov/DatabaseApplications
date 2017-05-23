using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class FootballExam
    {
        static void Main(string[] args)
        {
            var context = new FootballExamEntities();

            var teamNames = context.Teams.Select(t => t.TeamName);
            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}
