using System;
using System.Collections.Generic;
using PolymorphismC;
using PolymorphismC.Game;

namespace Polymorphism
{
    internal class Program
    {

        public delegate bool MyFilterDelegate(Person p);

        private static void Main(string[] args)
        {
            //Polymorphism
            Console.WriteLine("============ Polymorphism Examples =========");
            RunCarLogic();
            Console.WriteLine("\n");

            //Simple Delegate & abstract class
            Console.WriteLine("============  Abstract Class Examples =========");
            RunShapeLogic();
            Console.WriteLine("\n");

            Console.WriteLine("============ Simple Delegate Examples =========");
            RunPeopleLogic();
            Console.WriteLine("\n");

            Console.WriteLine("============ Multi Casting Delegates Examples =========");
            RunGameLogic();
            Console.WriteLine("\n");
        }

        private static void RunGameLogic()
        {
            AudioSystem audioSystem = new AudioSystem();
            RenderingEngine renderingEngine = new RenderingEngine();

            Player player1 = new Player("Bob");
            Player player2 = new Player("Jane");
            Player player3 = new Player("Mat");

            GameEventManager.TriggerGameStart();

            Console.WriteLine("Game is running...Press any key to end the game");

            Console.Read();

            GameEventManager.TriggerGameOver();

            Console.ReadKey();
        }

        private static void RunShapeLogic()
        {
            Shape[] shapes = { new Sphere(4), new Cube(3) };

            foreach (Shape shape in shapes)
            {
                shape.GetInfo();
                Console.WriteLine("{0} has a volume of {1}", shape.Name, shape.Volume());

                Cube iceCube = shape as Cube;
                if (iceCube != null)
                {
                    Console.WriteLine("This shape is no cube");
                }

                if (shape is Cube)
                {
                    Console.WriteLine("This is a cube");
                }

                object cube1 = new Cube(7);
                Cube cube2 = (Cube)cube1;

                Console.WriteLine("{0} has a volume of {1}", cube2.Name, cube2.Volume());
            }
        }

        private static void RunPeopleLogic()
        {
            Person p1 = new Person { Name = "Aiden", Age = 41 };
            Person p2 = new Person { Name = "Sif", Age = 69 };
            Person p3 = new Person { Name = "Walter", Age = 12 };
            Person p4 = new Person { Name = "Anatoli", Age = 25 };

            List<Person> people = new List<Person>() { p1, p1, p2, p3, p4 };

            DisplayPeople("Minors", people, IsAdult);
            DisplayPeople("Adults", people, IsAdult);
            DisplayPeople("Senior", people, IsAdult);

            //create a variable assigned to an anonymous method
            MyFilterDelegate filter = delegate (Person P)
            {
                return P.Age >= 20 && P.Age <= 30;
            };

            DisplayPeople("Custom between 20 & 30", people, filter);

            DisplayPeople("Show all", people, delegate (Person p) { return true; });
        }

        private static void RunCarLogic()
        {
            // Create a base class Car with two properties HP and Color
            // Create a Constructor setting those two properties
            // Create a Method called ShowDetails() which shows the HP and Color of the car on the console
            // Create a Repair Method which writes "Car was repaired!" onto the console
            // Create two deriving classes, BMW and Audi, which have their own constructor and have an aditional property
            // called Model. Also a private member called brand. Brand should be different in each of the two classes.
            // Create the two methods ShowDetails() and Repair in them as well. Adjust those methods accordingly
            // a car can be a BMW, an Audi, a Porsche etc.
            // Polymorphism at work #1: an Audi,  BMW, Porsche
            // can all be used whereever a Car is expected. No cast is
            // required because an implicit conversion exists from a derived
            // class to its base class
            var cars = new List<Car>
            {
                new Audi(200, "blue", "A4"),
                new BMW(250, "red", "M3")
            };

            // Polymorphism at work #2: the virtual method Repair is
            // invoked on each of the derived classes, not the base class.
            foreach (var car in cars)
            {
                car.Repair();
            }

            Car bmwZ3 = new BMW(200, "black", "Z3");
            Car audiA3 = new Audi(100, "green", "A3");
            bmwZ3.GetCarIDInfo();
            bmwZ3.ShowDetails();
            audiA3.ShowDetails();

            bmwZ3.SetCarIDInfo(1234, "Denis Panjuta");
            audiA3.SetCarIDInfo(1235, "Frank White");
            bmwZ3.GetCarIDInfo();
            audiA3.GetCarIDInfo();

            BMW bmwM5 = new BMW(330, "white", "M5");
            bmwM5.SetCarIDInfo(2222, "foo bar");
            bmwM5.GetCarIDInfo();
            bmwM5.ShowDetails();

            Car carB = (Car)bmwM5;
            carB.SetCarIDInfo(111, "baz moo");
            carB.GetCarIDInfo();
            carB.ShowDetails();

            M3 myM3 = new M3(260, "red", "M3 Super Turbo");
            myM3.Repair();
        }

        private static void DisplayPeople(string title, List<Person> people, MyFilterDelegate filer)
        {
            Console.WriteLine(title);
            foreach (Person p in people)
            {
                if (filer(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }
        }

        private static bool IsMinor(Person p)
        {
            return p.Age >= 18;
        }

        private static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        private static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }
    }
}
