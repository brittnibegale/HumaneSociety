using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Pet
    {
        string animal;
        string breed;
        int foodID;
        bool have_Shots;
        bool adoption_Status;
        string animal_Size;
        string energy_Type;
        bool likes_Kids;
        bool likes_Cats;
        bool likes_Dogs;
        bool trained;
        decimal cost;
        bool fed_Today;
        string yesOrNo;
        public Animal animals;

        public Pet()
        {

        }
        public void GetAnimalType()
        {
            Console.WriteLine("What type of animal are you dropping off? Dog, Cat, Bird, Rodent, Reptile");
            string animalType = Console.ReadLine().ToLower();
            animal = CheckAnimalType(animalType);
        }
        private string CheckAnimalType(string animalType)
        {
            while (true)
            {
                if (animalType == "dog" || animalType == "cat" || animalType == "reptile" || animalType == "rodent" || animalType == "bird")
                {
                    return animalType;
                }
                else
                {
                    Console.WriteLine("Please, type one of the choices: Dog, Cat, Bird, Rodent, Reptile");
                    animalType = Console.ReadLine().ToLower();
                }
            }
        }
        public void GetBreed()
        {
            Console.WriteLine("What is the breed of your animal?");
            breed = Console.ReadLine().ToLower();
        }
        public void GetFoodType()
        {
            if(animal == "dog")
            {
                foodID = 1;
            }
            else if(animal == "cat")
            {
                foodID = 2;
            }
            else if (animal == "rodent")
            {
                foodID = 3;
            }
            else if(animal == "bird")
            {
                foodID = 4;
            }
            else if(animal == "reptile")
            {
                foodID = 5;
            }
        }
        public void SetShots()
        {
            Console.WriteLine("Does your {0} have all of their shots? yes or no. If you don't know type no.", animal);
            yesOrNo = Console.ReadLine().ToLower();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if(yesOrNo == "yes")
            {
                have_Shots = true;
            }
            else
            {
                have_Shots = false;
            }
        }
        public void GetAnimalSize()
        {
            Console.WriteLine("What size is your {0}? extra small, small, medium, large, extra large", animal);
            string size = Console.ReadLine().ToLower().Trim();
            animal_Size = CheckSize(size);
        }
        private string CheckSize(string size)
        {
            while (true)
            {
                if (size == "extra small" || size == "small" || size == "medium" || size == "large" || size == "extra large")
                {
                    return size;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please, choose one of the following for size: extra small, small, medium, large, extra large");
                    size = Console.ReadLine().ToLower().Trim();
                }
            }
        }
        public void GetAnimalEnergyLevel()
        {
            Console.WriteLine("Does your {0} have a lot of energy? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if(yesOrNo == "yes")
            {
                energy_Type = "energic";
            }
            else
            {
                energy_Type = "calm";
            }
        }
        public void SetAnimalAdoptionStatus(bool status)
        {
            adoption_Status = status;
        }
        public void SetAnimalKidsLikability()
        {
            Console.WriteLine("Has your {0} ever been around children before? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower().Trim();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if(yesOrNo == "yes")
            {
                Console.WriteLine("Does your {0} do well with children? yes or no", animal);
                yesOrNo = Console.ReadLine().ToLower().Trim();
                yesOrNo = CheckyesOrNo(yesOrNo);
                if(yesOrNo == "yes")
                {
                    likes_Kids = true;
                }
                else
                {
                    likes_Kids = false;
                }
            }
            else
            {
                likes_Kids = false;
            }
        }
        public void SetAnimalCatsLikability()
        {
            Console.WriteLine("Has your {0} ever been around cats before? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower().Trim();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                Console.WriteLine("Does your {0} do well with cats? yes or no", animal);
                yesOrNo = Console.ReadLine().ToLower().Trim();
                yesOrNo = CheckyesOrNo(yesOrNo);
                if (yesOrNo == "yes")
                {
                    likes_Cats = true;
                }
                else
                {
                    likes_Cats = false;
                }
            }
            else
            {
                likes_Cats = false;
            }
        }
        public void SetAnimalDogsLikability()
        {
            Console.WriteLine("Has your {0} ever been around dogs before? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower().Trim();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if (yesOrNo == "yes")
            {
                Console.WriteLine("Does your {0} do well with dogs? yes or no", animal);
                yesOrNo = Console.ReadLine().ToLower().Trim();
                yesOrNo = CheckyesOrNo(yesOrNo);
                if (yesOrNo == "yes")
                {
                    likes_Dogs = true;
                }
                else
                {
                    likes_Dogs = false;
                }
            }
            else
            {
                likes_Dogs = false;
            }
        }
        public void SetAnimalTraining()
        {
            Console.WriteLine("Is your {0} trained well? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower().Trim();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if(yesOrNo == "yes")
            {
                trained = true;
            }
            else
            {
                trained = false;
            }
        }
        public void SetAnimalCost()
        {
            switch (animal)
            {
                case "dog":
                    cost = 200;
                    break;
                case "cat":
                    cost = 100;
                    break;
                case "bird":
                    cost = 50;
                    break;
                case "reptile":
                    cost = 25;
                    break;
                case "rodent":
                    cost = 10;
                    break;
                default:
                    break;
            }
        }
        public void SetAnimalFedStatus()
        {
            Console.WriteLine("Have you fed your {0} yet today? yes or no", animal);
            yesOrNo = Console.ReadLine().ToLower().Trim();
            yesOrNo = CheckyesOrNo(yesOrNo);
            if(yesOrNo == "yes")
            {
                fed_Today = true;
            }
            else
            {
                fed_Today = false;
            }
        }
        public void CreateAnimal()
        {
            animals = new Animal();
            animals.Animal1 = this.animal;
            animals.Breed = this.breed;
            animals.FoodID = this.foodID;
            animals.Have_Shots = this.have_Shots;
            animals.Adoption_Status = this.adoption_Status;
            animals.Animal_Size = this.animal_Size;
            animals.Energy_Type = this.energy_Type;
            animals.Likes_Kids = this.likes_Kids;
            animals.Likes_Cats = this.likes_Cats;
            animals.Likes_Dogs = this.likes_Dogs;
            animals.Trained = this.trained;
            animals.Cost = this.cost;
            animals.Fed_Today = this.fed_Today;
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
    }
}
