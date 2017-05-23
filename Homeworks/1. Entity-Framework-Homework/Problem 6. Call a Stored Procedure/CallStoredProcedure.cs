using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{

    public class CallStoredProcedure
    {
        static void Main(string[] args)
        {
            var db = new SoftUniEntities();

            db.GetProjectsOfEmployee("Rob", "Walters");
        }
    }    
}
