using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class AnimalIntakeManager:Employee
    {
        Pet pet;
        Animal animal;
        int count;
        public AnimalIntakeManager()
        {
            name = "Ben";
            jobTitle = "Animal Intake Manager";
            pet = new Pet();
            animal = new Animal();
            count = 1;
        }
        public void WelcomeMessage()
        {
            Console.WriteLine("Hi, my name is {0} I am the {1} here. I will help you will the process of submitting your animal to us. \n Let's get started.", name, jobTitle);
            Console.ReadLine();
        }
        public void GetAnimalInformation()
        {
            Animal animal = new Animal();
            animal = GetInformationAboutAnimal();
            GetRoomForAnimal(animal);
            ThankPerson();
        }
        private Animal GetInformationAboutAnimal()
        {
            pet.GetAnimalType();
            Console.Clear();
            pet.GetBreed();
            Console.Clear();
            pet.GetFoodType();
            Console.Clear();
            pet.SetShots();
            Console.Clear();
            pet.GetAnimalSize();
            Console.Clear();
            pet.GetAnimalEnergyLevel();
            Console.Clear();
            pet.SetAnimalAdoptionStatus(false);
            Console.Clear();
            pet.SetAnimalKidsLikability();
            Console.Clear();
            pet.SetAnimalCatsLikability();
            Console.Clear();
            pet.SetAnimalDogsLikability();
            Console.Clear();
            pet.SetAnimalTraining();
            Console.Clear();
            pet.SetAnimalCost();
            Console.Clear();
            pet.SetAnimalFedStatus();
            Console.Clear();
            pet.SetFoodAmount();
            Console.Clear();
            pet.CreateAnimal();
            animal = pet.animals;
            AddAnimalToDatabase(animal);
            return animal;
        }
        private void ThankPerson()
        {
            Console.WriteLine("Thank you for working with us. I ensure you that we will take great care of your animal.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void GetRoomForAnimal(Animal animals)
        {
            Room room = new Room();
            room.RoomNumber = count;
            room.Occupied = true;
            room.AnimalsID = animals.AnimalsID;
            AddAnimalToRoom(room);
        }
        private void AddAnimalToRoom(Room room)
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
    }
}
