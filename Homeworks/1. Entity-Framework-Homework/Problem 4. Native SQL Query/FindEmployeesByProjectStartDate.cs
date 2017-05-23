using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    public class FindEmployeesByProject_sStartDate
    {
        public static void PrintNamesWithLinqQuery_WithExtensionMethods()
        {
            var context = new SoftUniEntities();
            
                var queryResult = context.Employees
                    .Where(emp => emp.Projects.Any(p => p.StartDate.Year == 2002))
                    .Select(emp => emp.FirstName);

                var employees = queryResult.ToList();
                Console.WriteLine(string.Join(" | ", employees));
            
        }

        public static void PrintNamesWithLinqQuery_LINQtoEntities()
        {
            var context = new SoftUniEntities();
            
                var queryResult = (from e in context.Employees
                    where (from p in e.Projects
                    where p.StartDate.Year == 2002
                    select p).Any()
                    select e.FirstName);

                Console.WriteLine(string.Join(" | ", queryResult));
        }

        public static void PrintNamesWithNativeQuery()
        {
            var context = new SoftUniEntities();
    
                string nativeQuery =
                     "SELECT e.FirstName FROM Employees e " +
                     "WHERE EXISTS(SELECT p.ProjectID FROM Projects p " +
                     "LEFT JOIN EmployeesProjects ep " +
                     "ON p.ProjectID = ep.ProjectID " +
                     "LEFT JOIN Employees em " +
                     "ON ep.EmployeeID = em.EmployeeID " +
                     "WHERE em.EmployeeID = e.EmployeeID " +
                     "AND YEAR(p.StartDate) = 2002)";

                var queryResult = context.Database.SqlQuery<string>(nativeQuery);
                List<string> employees = queryResult.ToList();

                Console.WriteLine(string.Join(" | ", employees));
        }
    }
}
