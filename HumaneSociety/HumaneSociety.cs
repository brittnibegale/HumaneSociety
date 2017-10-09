using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class HumaneSociety
    {
        LinqToSQLDataContext first;
        Employee brittni;
        Adopter adopter;
        Customer customer;
        Animal animal;
        List<Animal> possiblePets;
        bool cats;
        bool dogs;
        bool kids;
        

        public HumaneSociety()
        {
            first = new LinqToSQLDataContext();
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
            brittni.GetRoomForAnimal();
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
            LinqToSQLDataContext addAdopter = new LinqToSQLDataContext();
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
            LinqToSQLDataContext compare = new LinqToSQLDataContext();
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
            LinqToSQLDataContext compare = new LinqToSQLDataContext();
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
            LinqToSQLDataContext compare = new LinqToSQLDataContext();
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
                LinqToSQLDataContext compare = new LinqToSQLDataContext();
                possiblePets = new List<Animal>();
                var catResult = compare.Animals.GroupBy(a => a.Likes_Cats).ToList();
                if (catResult.Count < 1)
                {
                    possiblePets = catResult[1].ToList();
                }
                else
                {
                    Console.WriteLine("We are sorry, but the current animals in our database do not get along with cats. \n Please, come again soon to see if we have gotten something that suits your family needs! Have a great day.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    
        private void CompareAdopterDogInfoToAnimals()
        {
            if(dogs == true)
            {
                List<Animal> tempAnimalList = new List<Animal>();

                foreach (var pet in possiblePets)
                {
                    if(animal.Likes_Dogs == true)
                    {
                        tempAnimalList.Add(pet);
                    }
                }
              possiblePets = tempAnimalList;
            }
            CheckListCount(possiblePets);
        }
        private void CompareAdopterKidInfoToAnimals()
        {
            if(kids == true)
            {
                List<Animal> tempAnimalList = new List<Animal>();
                foreach (var pet in possiblePets)
                {
                    if (animal.Likes_Kids == true)
                    {
                        tempAnimalList.Add(pet);
                    }
                }
                possiblePets = tempAnimalList;
            }
            CheckListCount(possiblePets);
        }

        private void CheckListCount(List<Animal> pet)
        {
            if(pet.Count < 1)
            {
                Console.WriteLine("Currently, there are no animals at our shelter that fit your family profile. \n Please, come back soon to check if we have gotten an animal that would fit your family!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
