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
        Animal animal;
        Pet pet;
        Room room;
        int count;
        public Employee()
        {
            name = "Brittni";
            jobTitle = "Manager";
            money = new MoneyBox();
            animal = new Animal();
            pet = new Pet();
            room = new Room();
            count = 1;
        }
      public void GetInformationAboutAnimal()
        {
            pet.GetAnimalType();
            pet.GetBreed();
            pet.GetFoodType();
            pet.SetShots();
            pet.GetAnimalSize();
            pet.GetAnimalEnergyLevel();
            pet.SetAnimalAdoptionStatus(false);
            pet.SetAnimalKidsLikability();
            pet.SetAnimalCatsLikability();
            pet.SetAnimalDogsLikability();
            pet.SetAnimalTraining();
            pet.SetAnimalCost();
            pet.SetAnimalFedStatus();
            pet.CreateAnimal();
            animal = pet.animals;
            AddAnimalToDatabase(animal);
            ThankPerson();
        }
        private void ThankPerson()
        {
            Console.WriteLine("Thank you for working with us. I ensure you that we will take great care of your animal.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void GetRoomForAnimal()
        {
            room.RoomNumber = count;
            room.Occupied = true;
            room.AnimalsID = animal.AnimalsID;
            AddAnimalToRoom();
        }
        public void AddAnimalToRoom()
        {
            LinqToSQLDataContext add = new LinqToSQLDataContext();
            add.Rooms.InsertOnSubmit(room);
            add.SubmitChanges();
            count++;
        }
        public void AddAnimalToDatabase(Animal animal)
        {
            LinqToSQLDataContext add = new LinqToSQLDataContext();
            add.Animals.InsertOnSubmit(animal);
            add.SubmitChanges();
        }
        private bool CheckForAnimalShots(Animal animal)
        {
            LinqToSQLDataContext check = new LinqToSQLDataContext();
            var pet = check.Animals.Single(i => i.AnimalsID == animal.AnimalsID);
            if(pet.Have_Shots == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AdoptionProcess(Customer adopter, Animal animal)
        {
            bool hasShots = CheckForAnimalShots(animal);
            DoesAnimalNeedShots(adopter, hasShots);
            ChangeAnimalToAdopted(adopter, animal);
            Console.WriteLine("Congrats on adopting the {0}! Thanks for supporting us! Have a great rest of your day!", animal.Breed);
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
                    TakeCustomersMoney(30, adopter);
                }
                else
                {
                    Console.WriteLine("I am sorry, but to take this animal home you need to buy their shots first. \n Are you sure you don't want to pay $30? yes or no");
                    yesOrNo = Console.ReadLine().ToLower().Trim();
                    yesOrNo = CheckyesOrNo(yesOrNo);
                    if(yesOrNo == "yes")
                    {
                        Console.WriteLine("Thank you for coming in today. Please, check back soon to see if there are any animals that fit your family!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else
                    {
                        TakeCustomersMoney(30, adopter);
                    }
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
        public void ChangeAnimalToAdopted(Customer customer, Animal animal)
        {
            LinqToSQLDataContext change = new LinqToSQLDataContext();
            var pet = change.Animals.Single(i => i.AnimalsID == animal.AnimalsID);
            pet.Adoption_Status = true;
            pet.AdopterID = customer.adopter.AdopterID;
            change.SubmitChanges();
        }
        public void TakeCustomersMoney(decimal cash, Customer adopter)
        {
            money.AddMoney(cash);
            adopter.Pay(cash);
        }
    }
}
