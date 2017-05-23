using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    class FindEmployeeById
    {
        public static void GetEmployeeById(int Id)
        {
            var context = new SoftUniEntities();

            var employees = context.Employees
                .Where(e => e.EmployeeID == Id)
                .OrderBy(e => e.JobTitle)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Project = e.Projects.Select(p => p.Name).FirstOrDefault()
                });


            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}: Job Title: {2}, Project: {3}",employee.FirstName,employee.LastName,employee.JobTitle,employee.Project);
            }
        }
    }
}
