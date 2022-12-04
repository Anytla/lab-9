using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComparingObjects_05
{
    public class Person : IComparable<Person> //реалізація класу через інтерфейс IComparable<> в якому є метод IComparer 
    {
        private string name; // є поля ім'я, вік та місто
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            private set
            {
                this.town = value;
            }
        }

        public int CompareTo(Person other) // метод Comparer - порівнює між собою двох людей 
        {
            int result = this.Name.CompareTo(other.Name); // спочатку їхні імена

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age); // далі їхній вік

                if (result == 0)
                {
                    result = this.Town.CompareTo(other.Town); // в кінці їхні міста
                }
            }

            return result;
        }
    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END") // після END програма закінчує роботу
            {
                string[] elements = input.Split(" ").ToArray();

                string name = elements[0];
                int age = int.Parse(elements[1]);
                string town = elements[2];

                Person person = new Person(name, age, town);
                people.Add(person); // додає та виводить персону з ім'ям, віком та містом
            }

            int numberTargetPerson = int.Parse(Console.ReadLine()); // людина з якою будуть відбуватись порівняння

            Person targetPerson = people[numberTargetPerson - 1]; // якшо буде хоч одне співп

            int counterEqualPeople = 0; // кількість співпадінь
            int counterNotEqualPeople = 0; // кількість не співпадінь

            foreach (Person person in people)
            {
                bool areEqual = person.CompareTo(targetPerson) == 0; // якщо буде хоч одне співпадіння
                if (areEqual)
                {
                    counterEqualPeople++;
                }
                else  // якщо не буде ні одного співпадіння
                {
                    counterNotEqualPeople++;
                }
            }

            bool areFound = counterEqualPeople > 1; // якщо будуть співпадіння
            if (areFound)
            {
                Console.WriteLine($"{counterEqualPeople} {counterNotEqualPeople} {people.Count}");
            }
            else // якщо не будуть співпадіння
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
