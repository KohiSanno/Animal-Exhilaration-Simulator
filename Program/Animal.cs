using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TextFile;
using System.Collections.Generic;

namespace HobbyAnimals
{
    public abstract class Animal
    {
        public virtual bool IsFish () { return false; }
        public virtual bool IsBird() { return false; }
        public virtual bool IsDog() { return false; }
        public bool IsEqual (Animal a) 
        {
            return this.IsFish() == a.IsFish() && this.IsBird() ==  a.IsBird() && this.IsDog() == a.IsDog() && this.Name == a.Name;
        }
        public string Name { get; }
        private int exhilarationLevel; // Change field accessibility to private

        public int ExhilarationLevel
        {
            get { return exhilarationLevel; }
            set { exhilarationLevel = value; }
        }
        public void ChangeExhilarationLevel(int el) { ExhilarationLevel += el; }
        protected Animal(string name, int level = 0) 
        { 
            this.Name = name; 
            this.ExhilarationLevel = level; 
        }

        public bool Alive() { return ExhilarationLevel > 0; }
        


    }

    public class Fish : Animal
    {
        public override bool IsFish() { return true; }
        public Fish(string name, int level = 0) : base(name, level) { }
        
    }

    public class Bird: Animal
    {
        public override bool IsBird() { return true; }
        public Bird(string name, int level = 0) : base(name, level) { }
       
    }

    public class Dog: Animal
    {
        public override bool IsDog() { return true; }
        public Dog(string name, int level = 0) : base(name, level) { }
      
    }
}