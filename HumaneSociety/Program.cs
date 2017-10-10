using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVFile file = new CSVFile();
            HumaneSociety first = new HumaneSociety(file);
            first.OpenHumaneSociety();
        }
    }
}
