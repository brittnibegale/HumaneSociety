using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class HumaneSociety
    {
        Employee employee = new Employee();
        Owner owner;
        AdoptionManager adoptionManager;
        AnimalIntakeManager intakeManager;
        Adopter adopter;
        Customer customer;
        Animal animal;
        List<Animal>possiblePets;
        List<Animal> intialPossiblePets;
        bool cats;
        bool dogs;
        bool kids;
        IimportFile file;

        public HumaneSociety(IimportFile file)
        {
            owner = new Owner();
            adoptionManager = new AdoptionManager();
            intakeManager = new AnimalIntakeManager();
            adopter = new Adopter();
            customer = new Customer();
            animal = new Animal();
            this.file = file;
        }
        public void OpenHumaneSociety()
        {
            FindCustomersAction();
        }
        public void FindCustomersAction()
        {
            Console.WriteLine("Welcome to the Humane Society! My name is {0}. I am the {1} of the Humane Society. Are you looking to adopt today or are you here to drop off an animal? \n Please choose: adopt or drop off",owner.name, owner.jobTitle);
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
                    AddAdopterToDatabase();
                    GetAdoptersFamilyInfo();
                    CompareAdopterCatInfoToAnimals();
                    CompareAdopterDogInfoToAnimals();
                    CompareAdopterKidInfoToAnimals();
                    SendOffToAdoptionManager();
                    Console.Clear();
                    adoptionManager.WelcomeMessage();
                    DisplayPossiblePets();
                    animal = customer.Search(possiblePets);
                    adoptionManager.AdoptionProcess(customer, animal);
                    break;
                case "drop off":
                    SendOffToIntakeManager();
                    Console.Clear();
                    intakeManager.WelcomeMessage();
                    Console.Clear();
                    string typeOfDropOff = GetTypeOfDropOff();
                    if(typeOfDropOff == "own animal")
                    {
                        intakeManager.GetAnimalInformation();
                    }
                    else
                    {
                        Console.WriteLine("Great, I see we have recieved your file of all the animals that are coming to our shelter.\n Let me process this and then you can be on your way!");
                        Console.ReadLine();
                        file.UploadFile(intakeManager);
                        Console.Clear();
                        Console.WriteLine("Looks like everything processed. Have a great day!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;
                default:
                    break;
            }
        }
        private string GetTypeOfDropOff()
        {
            Console.WriteLine("Are you here to drop off your own animal or a group of animals from another shelter? \n Please, choose: own animal or shelter animals");
            string typeOfDropOff = Console.ReadLine().ToLower().Trim();
            typeOfDropOff = CheckTypeOfDropOff(typeOfDropOff);
            return typeOfDropOff;
        }

        private string CheckTypeOfDropOff(string typeOfDropOff)
        {
            while (true)
            {
                if(typeOfDropOff == "own animal" || typeOfDropOff == "shelter animals")
                {
                    return typeOfDropOff;
                }
                else
                {
                    Console.WriteLine("Invaild input. Please, choose either own animal or shelter animals.");
                    typeOfDropOff = Console.ReadLine().ToLower().Trim();
                }
            }
        }
        private void SetAdoptersInformation()
        {
            Console.WriteLine("Before I send you off to our Adoption Manager, I need you to fill out this adopter profile to find the best pet to fit your family.");
            Console.ReadLine();
            Console.Clear();
            customer.GetName();
            Console.Clear();
            customer.GetAge();
            Console.Clear();
            customer.GetCatStatus();
            Console.Clear();
            customer.GetDogStatus();
            Console.Clear();
            customer.GetKidStatus();
            Console.Clear();
            customer.GetFirstAnimalStatus();
            Console.Clear();
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
        private void SendOffToAdoptionManager()
        {
            Console.WriteLine("Thank you for filling out our adopter profile. Let me get the Adoption Manager so we can get the ball rolling today!");
            Console.ReadLine();
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
        private void SendOffToIntakeManager()
        {
            Console.WriteLine("Thank you for choosing our humane society. Let me go get our Animal Intake Manager.");
            Console.ReadLine();
        }
    }
}
