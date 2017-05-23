using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    class FindEmlpoyeeByAdress
    {
        public static void FindAdressesWithEmployee()
        {
            var context = new SoftUniEntities();

            var adresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(e => e.Town.Name)
                .Take(10)
                .Select(e => new
                {
                    AdressText = e.AddressText,
                    Town = e.Town.Name,
                    EmployeesCount = e.Employees.Count
                });


            foreach (var adress in adresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", adress.AdressText, adress.Town, adress.EmployeesCount);
            }
        }


    }
}
