using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace HobbyAnimals
{
    public interface IMood
    {
        public void ChangeAnimal(Animal animal);
        /*public Mood ChangeFish(Fish el);
        public Mood ChangeBird(Bird el);
        public Mood ChangeDog(Dog el);*/
    }

    //class of ordinary

    class Ordinary : IMood
    {
        public void ChangeAnimal(Animal animal)
        {
            if (animal.IsFish())
            {
                animal.ChangeExhilarationLevel(-3);
            }

            if (animal.IsBird())
            {
                animal.ChangeExhilarationLevel(-1);

            }

        }


        private Ordinary() { }

        private static Ordinary? instance;
        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }

    }

    class Good : IMood
    {
        public void ChangeAnimal(Animal animal)
        {
            if (animal.IsFish())
            {
                animal.ChangeExhilarationLevel(+1);
            }

            if (animal.IsBird())
            {
                animal.ChangeExhilarationLevel(+2);

            }

            if (animal.IsDog())
            {
                animal.ChangeExhilarationLevel(+3);


            }
        }


        private Good() { }

        private static Good? instance;
        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }
    }


    class Bad : IMood
    {
        public void ChangeAnimal(Animal animal)
        {
            if (animal.IsFish())
            {
                animal.ChangeExhilarationLevel(-5);
            }

            if (animal.IsBird())
            {
                animal.ChangeExhilarationLevel(-3);

            }

            if (animal.IsDog())
            {
                animal.ChangeExhilarationLevel(-10);


            }
        }
        

        private Bad() { }

        private static Bad? instance;
        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }
    }
}
    

