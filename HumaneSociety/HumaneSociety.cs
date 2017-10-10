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
        List<Animal>possiblePets;
        List<Animal> intialPossiblePets;
        bool cats;
        bool dogs;
        bool kids;

        public HumaneSociety()
        {
            first = new LinqToSQLDataContext();
            brittni = new Employee();
            adopter = new Adopter();
            customer = new Customer();
            animal = new Animal();
        }
        public void OpenHumaneSociety()
        {
            FindCustomersAction();
        }
        public void FindCustomersAction()
        {
            Console.WriteLine("Welcome to the Humane Society! My name is {0}. Are you looking to adopt today or are you here to drop off an animal? \n Please choose: adopt or drop off");
            string choice = Console.ReadLine().ToLower();
            choice = CheckChoice(choice);
            CreateCustomerPath(choice);
        }
        private string CheckChoice(string choice)
        {
            while (true)
            {
                if(choice == "adopt" || choice == "drop off")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Please choose: adopt or drop off");
                    choice = Console.ReadLine().ToLower();
                }
            }
        }
        private void CreateCustomerPath(string choice)
        {
            switch (choice)
            {
                case "adopt":
                    SetAdoptersInformation();
                    Console.Clear();
                    AddAdopterToDatabase();
                    GetAdoptersFamilyInfo();
                    CompareAdopterCatInfoToAnimals();
                    CompareAdopterDogInfoToAnimals();
                    CompareAdopterKidInfoToAnimals();
                    DisplayPossiblePets();
                    animal = customer.Search(possiblePets);
                    brittni.AdoptionProcess(customer, animal);
                    break;
                case "drop off":
                    GetAnimalInformation();
                    break;
                default:
                    break;
            }
        }
        public void GetAnimalInformation()
        {
            brittni.GetInformationAboutAnimal();
            brittni.GetRoomForAnimal();
        }
        private void SetAdoptersInformation()
        {
            Console.WriteLine("My name is {0}. Let's have you fill out an adoption applilcation.", brittni.name);
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
            intialPossiblePets = new List<Animal>();

            if (cats == true)
            {
                LinqToSQLDataContext compare = new LinqToSQLDataContext();
                var catResult = compare.Animals.GroupBy(a => a.Likes_Cats).ToList();
                if (catResult.Count < 1)
                {
                    intialPossiblePets = catResult[1].ToList();
                }
                else
                {
                    Console.WriteLine("We are sorry, but the current animals in our database do not get along with cats. \n Please, come again soon to see if we have gotten an animal that suits your family needs! Have a great day.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            else
            {
                LinqToSQLDataContext create = new LinqToSQLDataContext();
                var animals = create.Animals.Select(animal => animal);
                foreach(var animal in animals)
                {
                    intialPossiblePets.Add(animal);
                }
            }
        }
        private void CompareAdopterDogInfoToAnimals()
        {
            possiblePets = new List<Animal>();
            possiblePets = intialPossiblePets;
            if (dogs == true)
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
        private void DisplayPossiblePets()
        {
            int count = 1;
            Console.WriteLine("Here is a list of the animals that fit your family.");
            foreach(var animal in possiblePets)
            {
                Console.WriteLine("{0}. {1} of {2} breed.", count, animal.Animal1, animal.Breed);
                count++;
            }
            Console.ReadLine();
        }
    }
}
