using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Customer
    {
        decimal wallet = 0;
        string name;
        int age;
        bool hasCats;
        bool hasDogs;
        bool hasKids;
        bool firstAnimal;
        public Adopter adopter;
        List<Animal> searchedAnimals;

        public Customer()
        {
            wallet = 300;
            searchedAnimals = new List<Animal>();
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
                    break;
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
        public void CreateAdopter()
        {
            adopter = new Adopter();
            adopter.Name = this.name;
            adopter.Age = this.age;
            adopter.Have_Cats = this.hasCats;
            adopter.Have_Dogs = this.hasDogs;
            adopter.Have_Kids = this.hasKids;
            adopter.First_Animal = this.firstAnimal;
            adopter.Wallet = this.wallet;
        }
        public void Pay(decimal cost)
        {
            LinqToSQLDataContext remove = new LinqToSQLDataContext();
            var person = remove.Adopters.Single(i => i.Name == adopter.Name);
            decimal money = wallet - cost;
            person.Wallet = money;
            remove.SubmitChanges();
        }
        public Animal Search(List<Animal> possiblePets)
        {
            Console.WriteLine("What would you like to search by? animal type, breed, size");
            string userSearchInput = Console.ReadLine().ToLower();
            userSearchInput = CheckSearch(userSearchInput);
            searchedAnimals = SearchToTakePlace(possiblePets, userSearchInput);
            DisplaySearchedAnimals(searchedAnimals);
            Animal pet;
            pet = ChooseToSearchAgain(searchedAnimals);
            return pet; 
        }
        private List <Animal> SearchToTakePlace(List<Animal>possiblePets, string userSearchInput)
        {
            List<Animal> searchedAnimals = new List<Animal>();
            switch (userSearchInput)
            {
                case "animal type":
                    searchedAnimals = SearchByType(possiblePets);
                    return searchedAnimals;
                case "breed":
                    searchedAnimals = SearchByBreed(possiblePets);
                    return searchedAnimals;
                case "size":
                    searchedAnimals = SearchBySize(possiblePets);
                    return searchedAnimals;
                default:
                    break;
            }
            return searchedAnimals;
        }
        private List<Animal> SearchByType(List<Animal> possiblePets)
        {
            List<Animal> searchedAnimals = new List<Animal>();
            string typeChoice;
            Console.WriteLine("What type of animal are you looking for? dog, cat, bird, reptile, rodent");
            typeChoice = Console.ReadLine().ToLower();
            typeChoice = CheckTypeChoice(typeChoice);

            foreach(var pet in possiblePets)
            {
                if(pet.Animal1 == typeChoice)
                {
                    searchedAnimals.Add(pet);
                }
            }
            CheckCount(searchedAnimals);
            return searchedAnimals;
        }
        private List<Animal> SearchByBreed(List<Animal> possiblePets)
        {
            List<Animal> searchedAnimals = new List<Animal>();
            string typeChoice;
            Console.WriteLine("What breed of animal are you looking for?");
            typeChoice = Console.ReadLine().ToLower();

            foreach (var pet in possiblePets)
            {
                if (pet.Breed == typeChoice)
                {
                    searchedAnimals.Add(pet);
                }
            }
            CheckCount(searchedAnimals);
            return searchedAnimals;
        }
        private List<Animal> SearchBySize(List<Animal> possiblePets)
        {
            List<Animal> searchedAnimals = new List<Animal>();
            string typeChoice;
            Console.WriteLine("What size of animal are you looking for? extra small, small, medium, large, extra large");
            typeChoice = Console.ReadLine().ToLower();
            typeChoice = CheckSizeChoice(typeChoice);

            foreach (var pet in possiblePets)
            {
                if (pet.Animal_Size == typeChoice)
                {
                    searchedAnimals.Add(pet);
                }
            }
            CheckCount(searchedAnimals);
            return searchedAnimals;
        }
        private string CheckSearch(string userSearchInput)
        {
            while (true)
            {
                if (userSearchInput == "animal type" || userSearchInput == "breed" || userSearchInput == "size")
                {
                    return userSearchInput;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please, choose: animal type, breed, or size.");
                    userSearchInput = Console.ReadLine().ToLower();
                }
            }
        }
        private string CheckTypeChoice(string typeChoice)
        {
            while (true)
            {
                if(typeChoice == "dog" || typeChoice == "cat" || typeChoice == "bird" || typeChoice == "reptile" || typeChoice == "rodent")
                {
                    return typeChoice;
                }
                else
                {
                    Console.WriteLine("Invaild choice. Please, choose: dog, cat, bird, reptile, or rodent");
                    typeChoice = Console.ReadLine().ToLower();
                }
            }
        }
        private string CheckSizeChoice(string typeChoice)
        {
            while (true)
            {
                if(typeChoice == "extra small" || typeChoice == "small" || typeChoice == "medium" || typeChoice == "large" || typeChoice == "extra large")
                {
                    return typeChoice;
                }
                else
                {
                    Console.WriteLine("Invaild size. Please, choose: extra small, small, medium, large or extra large.");
                    typeChoice = Console.ReadLine().ToLower();
                }
            }
        }
        private int CheckCount(List<Animal> possibleAnimals)
        {
            if(possibleAnimals.Count <= 1)
            {
                Console.WriteLine("There are no animals that meet your search. Please, come back soon and check if we have the animal that fits your family!");
                Console.ReadLine();
                Environment.Exit(0);
            }
           return possibleAnimals.Count();
        }
        private void DisplaySearchedAnimals(List<Animal> possibleAnimals)
        {
            int count = 1;
            Console.WriteLine("Here is a list of the animals that fit your family.");
            foreach (var animal in possibleAnimals)
            {
                Console.WriteLine("{0}. {1} of {2} breed.", count, animal.Animal1, animal.Breed);
                count++;
            }
            Console.ReadLine();
        }
        private Animal ChooseToSearchAgain(List<Animal> possibleAnimals)
        {
            while (true)
            {
                Console.WriteLine("From the list above have you narrowed you choices far enough? yes or no");
                string yesOrNo = Console.ReadLine().ToLower();
                yesOrNo = CheckyesOrNo(yesOrNo);
                if (yesOrNo == "yes")
                {
                    Animal pet;
                    pet = ChooseAnimal(possibleAnimals);
                    return pet;
                }
                else
                {
                    Search(possibleAnimals);
                }
            }
        }
        private Animal ChooseAnimal(List<Animal> possibleAnimals)
        {
            int number;
            Animal pet;
            int count = CheckCount(possibleAnimals);
            Console.WriteLine("Please, type the number associated with the animal you would like. \n Example: 1. Dog of Corgi breed. You would type 1. \n Please, choose a number less than {0}", count);
            string numberChoice = Console.ReadLine();
            number = CheckNumberValidity(numberChoice, count);
            number = number - 1;
            pet = possibleAnimals[number];
            return pet;
        }
        private int CheckNumberValidity(string numberChoice, int count)
        {
            while (true)
            {
                int number;
                if (Int32.TryParse(numberChoice, out number))
                {
                    if (number > count)
                    {
                        Console.WriteLine("Please, choose an animal from the list above with a corresponding number less than {0}.", count);
                        numberChoice = Console.ReadLine();
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter an integer number for your choice. Less than {0}.", count);
                    numberChoice = Console.ReadLine();
                }
            }
        }
    }
}
