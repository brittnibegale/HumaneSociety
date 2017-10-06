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
        Customer adopter;

        public HumaneSociety()
        {
            first = new LinqtoSQLDataContext();
            brittni = new Employee();
            adopter = new Customer();
        }

        public void GetAdoptersInformation()
        {
            Console.WriteLine("Welcome to the Humane Socitey! My name is {0}. Let's have you fill out an adoption applilcation.", brittni.name);
            Console.ReadLine();

        }
    }
}
