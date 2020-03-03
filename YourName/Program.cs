using System;
using System.Collections.Generic;
using System.Linq;

namespace YourName
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();
            Dog dog = new Dog();
            dog.Name = "Toby";

            Cat cat = new Cat();
            cat.Name = "Missy";

            Console.WriteLine(dog.Name);
            dog.Talk();


            var animal = animals.FirstOrDefault(x => x.Name == "Toby");
            animal.Talk();

            Console.ReadLine();
        }

        public abstract class Animal
        {
            public string Name { get; set; }

            public virtual void Talk()
            {
                Console.WriteLine("Hello");
            }


        }

        public class Dog : Animal
        {
            public override void Talk()
            {
                Console.WriteLine("Bark");
            }
        }

        public class Cat : Animal
        {
            public override void Talk()
            {
                Console.WriteLine("Meow");
            }
        }

        public class Bird : Animal
        {
            public override void Talk()
            {
                Console.WriteLine("Tweet");
            }
        }

        public class Snake : Animal
        {
            public override void Talk()
            {
                Console.WriteLine("snake");
            }
        }

    }
}
