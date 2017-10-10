using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace HumaneSociety
{
    public class CSVFile: IimportFile
    {
        string path = "newFile.csv";
        public CSVFile()
        {

        }

        public void UploadFile(Employee employee)
        {
            LinqToSQLDataContext add = new LinqToSQLDataContext();
            var animalData = File.ReadLines(path).Select(path => path.Split(',')).ToList();
            foreach(var line in animalData)
            {
                Animal animal = new Animal();
                animal.Animal1 = line[0].ToLower();
                animal.Breed = line[1].ToLower();
                animal.FoodID = Int32.Parse(line[2]);
                animal.Have_Shots = Convert.ToBoolean(line[3]);
                animal.Adoption_Status = Convert.ToBoolean(line[4]);
                animal.Animal_Size = line[5].ToLower();
                animal.Energy_Type = line[6].ToLower();
                animal.Likes_Kids = Convert.ToBoolean(line[7]);
                animal.Likes_Cats = Convert.ToBoolean(line[8]);
                animal.Likes_Dogs = Convert.ToBoolean(line[9]);
                animal.Trained = Convert.ToBoolean(line[10]);
                animal.Cost = Decimal.Parse(line[11]);
                animal.Fed_Today = Convert.ToBoolean(line[12]);

                add.Animals.InsertOnSubmit(animal);
                add.SubmitChanges();
                employee.GetRoomForAnimal(animal);
            }
        }
    }
}
