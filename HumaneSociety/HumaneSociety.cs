using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class HumaneSociety
    {
        LinqtoSQLDataContext first;
        Employee brittni;

        public HumaneSociety()
        {
            first = new LinqtoSQLDataContext();
            brittni = new Employee();
        }
    }
}
