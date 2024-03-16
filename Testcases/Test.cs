using Microsoft.VisualStudio.TestTools.UnitTesting;
using HobbyAnimals;
using System.Collections.Generic;

namespace Testcases
{
    [TestClass]
    public class Test
    {

        //Testing the number of animals
        [TestMethod]
        public void NoAnimal()
        {
            List<Animal> animals = new List<Animal>(); //actual
            
            Program.Execute("Input1.txt", ref animals);
            List<Animal> animals2 = new List<Animal>(); //expected
            Assert.AreEqual(0, animals.Count);

            // Assert that the animals list matches the expected list (empty in this case)
            CollectionAssert.AreEqual(animals2, animals);
        }


        [TestMethod]
        public void OneAnimal()
        {
            List<Animal> animals = new List<Animal>(); //actual
            List<IMood> days = new List<IMood>();
            Program.Execute("Input2.txt", ref animals);

            List<Animal> animals2 = new List<Animal>(); 
            Fish f1 = new Fish("Nemo", 50);
            animals2.Add(f1);//expected
            for (int i = 0; i < animals.Count; i++)
            {
                Assert.IsTrue(animals2[i].IsEqual(animals[i]));
            }
        }


        [TestMethod]
        public void MoreThanOneAnimal()
        {
            List<Animal> animals = new List<Animal>(); //actual
            Program.Execute("Input.txt", ref animals);

            List<Animal> animals3 = new List<Animal>();
            Dog a1 = new Dog("Lassie", 20);
            Dog a2 = new Dog("Dory", 20);
            animals3.Add(a1);
            animals3.Add(a2);//expected
            for (int i = 0; i < animals.Count; i++)
            {
                //Assert.IsTrue(animals2[i].Name == animals[i].Name);
                Assert.AreEqual(animals3[i].Name,animals[i].Name);
            }
            Assert.AreEqual(2, animals.Count);
        }



        

        //Testing the different exhilaration levels of the animals

        [TestMethod]
        public void AllDead()
        {
            List<Animal> animals = new List<Animal>(); //actual
            Program.Execute("Input3.txt", ref animals);
            List<Animal> animals2 = new List<Animal>(); //expected
            CollectionAssert.AreEqual(animals2, animals);

            // Assert that the animals list is empty
            Assert.AreEqual(0, animals.Count);
        }

        [TestMethod]
        public void MoreThanOneAnimalLowLevel()
        {
            List<Animal> animals = new List<Animal>(); //actual
            Program.Execute("Input.txt", ref animals);

            List<Animal> animals3 = new List<Animal>();
            Dog a1 = new Dog("Lassie", 20);
            Dog a2 = new Dog("Dory", 20);
            animals3.Add(a1);
            animals3.Add(a2);//expected
            for (int i = 0; i < animals.Count; i++)
            {
                //Assert.IsTrue(animals2[i].Name == animals[i].Name);
                Assert.AreEqual(animals3[i].Name,animals[i].Name);
            }
  
        }


    }
}