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
        Adopter adopter;
        Customer customer;
        bool cats;
        bool dogs;
        bool kids;

        public HumaneSociety()
        {
            first = new LinqtoSQLDataContext();
            brittni = new Employee();
            adopter = new Adopter();
            customer = new Customer();

        }
        public void OpenHumaneSociety()
        {
            GetAdoptersInformation();
            AddAdopterToDatabase();
            GetAdoptersFamilyInfo();
        }
        private void GetAdoptersInformation()
        {
            Console.WriteLine("Welcome to the Humane Socitey! My name is {0}. Let's have you fill out an adoption applilcation.", brittni.name);
            Console.ReadLine();
            customer.GetName();
            customer.GetAge();
            customer.GetCatStatus();
            customer.GetDogStatus();
            customer.GetKidStatus();
            customer.GetFirstAnimalStatus();
            adopter = customer.adopter;
        }
        private void AddAdopterToDatabase()
        {
            LinqtoSQLDataContext addAdopter = new LinqtoSQLDataContext();
            addAdopter.Adopters.InsertOnSubmit(adopter);
            addAdopter.SubmitChanges();
        }
        private void GetAdoptersFamilyInfo()
        {
            cats = GetAdoptersCatStatus();
            dogs = GetAdoptersDogStatus();
            kids = GetAdoptersKidStatus();
        }
        private bool GetAdoptersCatStatus()
        {
            LinqtoSQLDataContext compare = new LinqtoSQLDataContext();
            var person = compare.Adopters.Single(i => i.Name == adopter.Name);
            if(person.Have_Cats == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool GetAdoptersDogStatus()
        {
            LinqtoSQLDataContext compare = new LinqtoSQLDataContext();
            var person = compare.Adopters.Single(i => i.Name == adopter.Name);
            if (person.Have_Dogs == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool GetAdoptersKidStatus()
        {
            LinqtoSQLDataContext compare = new LinqtoSQLDataContext();
            var person = compare.Adopters.Single(i => i.Name == adopter.Name);
            if (person.Have_Kids == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
