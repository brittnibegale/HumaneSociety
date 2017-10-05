using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Employee
    {
        string name;
        string jobTitle;
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
        }

        public void CheckForAnimalShots()
        {

        }
        public void AdoptionProcess()
        {

        }
        public void ChangeAnimalToAdopted(string status)
        {

        }
       
        public void TakeCustomersMoney()
        {
            double cash = 100.00;
            money.AddMoney(cash);
        }

    }
}
