using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Employee
    {
        public string name;
        string jobTitle;
        string yesOrNo;
        MoneyBox money;
        public Employee()
        {
            name = "Brittni";
            jobTitle = "Manager";
            money = new MoneyBox();
        }
      
        public void AddAnimalToDatabase(Animal animal)
        {
            LinqtoSQLDataContext add = new LinqtoSQLDataContext();
            add.Animals.InsertOnSubmit(animal);
            add.SubmitChanges();
        }

        private bool CheckForAnimalShots(Animal animal)
        {
            bool hasShots = false;
            return hasShots;
        }
        public void AdoptionProcess(Customer adopter, Animal animal)
        {
            bool hasShots = CheckForAnimalShots(animal);
            DoesAnimalNeedShots(adopter, hasShots);
            ChangeAnimalToAdopted(adopter, animal);
            Console.WriteLine("Congrats on adopting the {0}! Thanks for supporting us! Have a great rest of your day!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private void DoesAnimalNeedShots(Customer adopter, bool hasShots)
        {
            if (!(hasShots == true))
            {
                Console.WriteLine("The animal you want does not have their shots. It is $30 for their shots. \n Are you willing to pay $30 for their shots? yes or no");
                yesOrNo = Console.ReadLine().ToLower().Trim();
                yesOrNo = CheckyesOrNo(yesOrNo);
                if(yesOrNo == "yes")
                {
                    TakeCustomersMoney(30);
                }
                else
                {
                    Console.WriteLine("I am sorry, but to take this animal home you need to buy their shots first. \n Would you like to search for an animal again? yes or no");
                    yesOrNo = Console.ReadLine().ToLower().Trim();
                    yesOrNo = CheckyesOrNo(yesOrNo);
                    SendBackToSearch(adopter, yesOrNo);
                    //figure out what should happen next
                }

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
        public void ChangeAnimalToAdopted(Customer adopter, Animal animal)
        {

        }

        private void SendBackToSearch(Customer adopter, string yesOrNo)
        {
            if(yesOrNo == "yes")
            {
                adopter.Search();
            }
            else
            {
                Console.WriteLine("Thank you for stopping in today to check out our humane socitey! \n Keep checking in to see if we get an animal you would like to add to your family!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
       
        public void TakeCustomersMoney(decimal cash)
        {
            
            money.AddMoney(cash);
        }

    }
}
