using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    class ConcurentDatabaseChanges
    {
        public static void DataChanges()
        {
            var ctx1 = new SoftUniEntities();

            var employee1 = ctx1.Employees.Find(1);
            employee1.FirstName = "Gosho";

            var ctx2 = new SoftUniEntities();

            var employee2 = ctx2.Employees.Find(1);
            employee2.FirstName = "Vanka";

            ctx1.SaveChanges();
            ctx2.SaveChanges();
        }
    }
}
