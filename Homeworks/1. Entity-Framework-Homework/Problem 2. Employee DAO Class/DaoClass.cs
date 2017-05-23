using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Softuni
{
    class DaoClass
    {
        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();

            var entry = context.Entry(employee);
            entry.State = EntityState.Added;

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var context = new SoftUniEntities();
            
            Employee employee = context.Employees.Find(key);

            return employee;
            
        }

        public static void Modify(Employee employee, string newName)
        {
            var context = new SoftUniEntities();

            string[] name = Regex.Split(newName.Trim(), @"\s+");
            string firstName = Regex.Split(newName.Trim(), @"\s+")[0];
            employee.FirstName = firstName;

            if (name.Length == 2)
            {
                string lastName = Regex.Split(newName.Trim(), @"\s+")[0];
                employee.LastName = lastName;
            }

            var entry = context.Entry(employee);
            entry.State = EntityState.Modified;

            context.SaveChanges();
            
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();
            
            context.Entry(employee).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
