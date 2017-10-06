using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Customer
    {
        MoneyBox wallet;
        string name;
        int age;
        bool hasCats;
        bool hasDogs;
        bool hasKids;
        bool firstAnimal;

        public Customer()
        {
            wallet = new MoneyBox();
            
            //hasCats = GetCatStatus();
            //hasDogs = GetDogStatus();
            //hasKids = GetFamilyStatus();
            //firstAnimal = GetAnimalStatus();
        }

        public void GetName()
        {
            Console.WriteLine("What is your name?");
            name = Console.ReadLine().Trim();
        }
        public void GetAge()
        {
            int x;
            Console.WriteLine("What is your age?");
            string inputAge = Console.ReadLine();
            while (true)
            {
                if (Int32.TryParse(inputAge, out x))
                {
                    age = x;
                }
                else
                {
                    Console.WriteLine("Please, enter an integer number for your age.");
                    inputAge = Console.ReadLine();
                }
            }
        }

        public void Search()
        {

        }
    }
}
