//Author: Kohiro Sannomiya
//Date: 2023.05.07
//Title: Exhilaration of hobby animals


using System;
using TextFile;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HobbyAnimals
{
    public class Program
    {
        public static void Execute(string filename, ref List<Animal> animals)
        {
            //string filename = Console.ReadLine();
            TextFileReader reader = new TextFileReader(filename);

            //first line: number of animals
            reader.ReadLine(out string line);
            int n = Convert.ToInt32(line);

            //taking in the data of animals
            //animals = new List<Animal>();

            for (int i = 0; i < n; i++)
            {
                if (reader.ReadLine(out line))
                {
                    string[] Data = line.Split(" ");
                    char animal = Convert.ToChar(Data[0]);
                    string name = Data[1];
                    int ExhilarationLevel = Convert.ToInt32(Data[2]);

                    //Console.WriteLine(name);

                    switch (animal)
                    {
                        case 'F':
                            animals.Add(new Fish(name, ExhilarationLevel));
                            break;

                        case 'B':
                            animals.Add(new Bird(name, ExhilarationLevel));
                            break;

                        case 'D':
                            animals.Add(new Dog(name, ExhilarationLevel));
                            break;
                    }

                }
            }
            //animals are full

            //taking in the mood of the carekeeper
            reader.ReadLine(out line);
            char[] days = line.ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char day in days)
            {
                switch (day)
                {
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                    case 'g': moods.Add(Good.Instance()); break;
                }
            }
          

            int minexlevel = 999;
            //affect
            for (int i = 0; i < moods.Count; ++i)
            {
                foreach (Animal animal in animals)
                {
                    moods[i].ChangeAnimal(animal);
                }
            }


            for(int i = 0; i < animals.Count; i++)
            {
                if (animals[i].ExhilarationLevel < minexlevel && animals[i].Alive())
                {
                    minexlevel = animals[i].ExhilarationLevel;
                }
            }
            List <Animal> buf = new List<Animal>();
            for (int i = 0; i < animals.Count; i++)
            {
                buf.Add(animals[i]);
            }

            ///////////////////////////
            /*for (int i = 0; i < animals.Count; ++i)
            {
                Console.WriteLine(buf[i].Name);
            }*/
            ///////////////////////////
           
            animals.Clear();//animals are empty.

            for (int i = 0; i < buf.Count; ++i)
            {
                if (buf[i].ExhilarationLevel == minexlevel && buf[i].Alive())
                {
                    animals.Add(buf[i]);
                    Console.WriteLine(buf[i].Name);
                }
            }


        }


        public static void Main(string[] args)
        {
            string? filename = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            if (animals != null && filename != null)
            {
                Execute(filename, ref animals);
            }
            else
            {
                // No action required when animals is null
            }
        }
    }
}