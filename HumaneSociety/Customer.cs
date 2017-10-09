using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Customer
    {
        decimal wallet;
        string name;
        int age;
        bool hasCats;
        bool hasDogs;
        bool hasKids;
        bool firstAnimal;
        public Adopter adopter;

        public Customer()
        {
            wallet = 300;
            adopter = new Adopter();
            adopter.Name = this.name;
            adopter.Age = this.age;
            adopter.Have_Cats = this.hasCats;
            adopter.Have_Dogs = this.hasDogs;
            adopter.Have_Kids = this.hasKids;
            adopter.First_Animal = this.firstAnimal;
            adopter.Wallet = this.wallet;
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

        public void GetCatStatus()
        {
            Console.WriteLine("Do you have any cats at home? yes or no");
            string yesOrNo = Console.ReadLine();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                hasCats = true;
            }
            else
            {
                hasCats = false;
            }
        }

        public void GetDogStatus()
        {
            Console.WriteLine("Do you have any dogs at home? yes or no");
            string yesOrNo = Console.ReadLine();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                hasDogs = true;
            }
            else
            {
                hasDogs = false;
            }
        }
        public void GetKidStatus()
        {
            Console.WriteLine("Do you have any children? yes or no");
            string yesOrNo = Console.ReadLine();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                hasKids = true;
            }
            else
            {
                hasKids = false;
            }
        }

        public void GetFirstAnimalStatus()
        {
            Console.WriteLine("Have you ever had an animal before? yes or no");
            string yesOrNo = Console.ReadLine();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                firstAnimal = true;
            }
            else
            {
                firstAnimal = false;
            }
        }
        private string CheckyesOrNo(string yesOrNo)
        {
            while (true)
            {
                if (yesOrNo == "yes" || yesOrNo == "no")
                {
                    return yesOrNo;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please, choose yes or no.");
                    yesOrNo = Console.ReadLine();
                }
            }
        }

        public void Search()
        {

        }
    }
}
