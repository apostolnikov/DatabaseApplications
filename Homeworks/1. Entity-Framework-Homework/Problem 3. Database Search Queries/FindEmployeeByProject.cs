using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    public class FindEmployeeByProject
    {
        public static void FindEmployeesWithProjects()
        {
            var context = new SoftUniEntities();

            var FirstDate = new DateTime(2000, 12, 31);
            var secondDate2 = new DateTime(2003, 12, 31);

            var employees = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate > FirstDate && p.StartDate <= secondDate2));



            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName + ": ");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine(" Project: " + project.Name + " Start Date: " + project.StartDate.ToString("dd-MM-yyyy") + " End Date:" + project.EndDate);
                }
                Console.WriteLine();
            }
        }
    }
}
