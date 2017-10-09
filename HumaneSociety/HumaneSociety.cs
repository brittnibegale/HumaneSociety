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
        Animal animal;
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
            CompareAdopterCatInfoToAnimals();
            CompareAdopterDogInfoToAnimals();
            CompareAdopterKidInfoToAnimals();
        }

        public void GetAnimalInformation()
        {
            brittni.GetInformationAboutAnimal();
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
            customer.CreateAdopter();
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
        private void CompareAdopterCatInfoToAnimals()
        {
            if(cats == true)
            {
                LinqtoSQLDataContext compare = new LinqtoSQLDataContext();
                var result = compare.Animals.GroupBy(a => a.Likes_Cats).Select(i => i.ToList()).ToList();
               
            }

        }
    
        private void CompareAdopterDogInfoToAnimals()
        {
            if(dogs == true)
            {
                LinqtoSQLDataContext compare = new LinqtoSQLDataContext();

            }

        }
            private void CompareAdopterKidInfoToAnimals()
        {
            if(kids == true)
            {
                LinqtoSQLDataContext compare = new LinqtoSQLDataContext();

            }

        }
    }
}
