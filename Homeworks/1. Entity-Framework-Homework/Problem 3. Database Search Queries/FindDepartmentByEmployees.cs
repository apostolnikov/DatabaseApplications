using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    class FindDepartmentByEmployees
    {
        public static void FindDepartmantWithMoreThan5Employees()
        {
            var context = new SoftUniEntities();

            var departments = context.Departments
                .Where(dep => dep.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    Manager = d.Employee.FirstName + " " + d.Employee.LastName,
                    Employees = d.Employees.Count
                }).ToList();

            Console.WriteLine(departments.Count);

            foreach (var dep in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    dep.DepartmentName,
                    dep.Manager,
                    dep.Employees);
            }
        }
    }
}
