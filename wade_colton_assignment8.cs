using System;
using System.Collections.Generic;
using static System.Console;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
           // Result Variable 
           // Person result;

            // Instansiates PersonData
            PersonData PD = new PersonData();

            // Instansiates Person, Adds Person using PersonData's addPerson() Method, then Prints person
            // by calling PersonData's printPerson() method with the Person's Index

            Person Test = new Person("Tester", "32", "175.8"); // Invalid Name
            PD.addPerson(Test);                                 // Adds Person to PersonData's PersonList List
            PD.printPerson(1);                                  // Prints Index Position 


            Person Colton = new Person("Colton Wade", "19", "145.76");
            PD.addPerson(Colton);
            PD.printPerson(2);


            Person Gavin = new Person("GavinBlake", "125", "210.4"); // Name and Age Error
            PD.addPerson(Gavin);
            PD.printPerson(3);

            Person Demetri = new Person("Demetri Mano", "22asdas", "125.32"); // Invalid Age
            PD.addPerson(Demetri);
            PD.printPerson(4);

            Person Crystal = new Person("Crystal Hutchins", "21", "135.45asdsa"); // Invalid Weight
            PD.addPerson(Crystal);
            PD.printPerson(5);

            PD.printPerson(6);                                  // Calls Index Posotion that does not exist



        }


        // -----------------Person Class----------------- \\
        class Person
        {
            // Instance Variables 
            private string name;
            private string age;
            private string weight;

            // Class Contructor
            public Person(string name, string age, string weight)
            {
                this.name = name;
                this.age = age;
                this.weight = weight;


                // ----------------- Name Validation ----------------- \\

                // Try/Catch Block
                try
                {
                    // If Person's name is less than 5 characters, or greater than 120 characters, or the person's name doesnt contain a space
                    // It will throw a ArgumentException error
                    if (name.Length < 5 || name.Length > 120 || !name.Contains(" ")) 
                    {
                        throw new ArgumentException();
                    }
 
                }
                // Catches exception and prints error message
                catch (ArgumentException)
                {
                    WriteLine("Name Must Be 5-120 Characters and Have Space!");
                }


                // ----------------- Age Validation ----------------- \\
                // Try/Catch Block
                try
                {
                    // If Age is Less than 1 Or Greater Than 120 it will throw an ArgumentException
                    // If age is not an Integer it will throw a FormatException
                    if (int.Parse(age) < 1 || int.Parse(age) > 120)
                    {
                        throw new ArgumentException();
                    }
                }
                // Catches ArgumentException and prints an error message
                catch (ArgumentException)
                {
                    WriteLine("Age Must Be Bewtween 1-120");
                }
                // Catche FormatException and prints an error message, and sets age equal to 0
                catch (FormatException)
                {
                    this.age = "0";
                    WriteLine("Age Must Be an Integer!");
                }

                //----------------- Weight Validaiton ----------------- \\
                // Try/Catch Block
                try
                {
                    // If Age is not an Integer/Double or Less than 1 it will throw an ArgumentException
                    if (double.Parse(weight) < 1)
                    {
                        throw new ArgumentException();
                    }

                }
                // Catches ArgumentException and prints an error message
                catch (ArgumentException)
                {
                    WriteLine("Weight Must Be Greater Than 1");
                }
                // Catches FormatException and prints an error message, and sets weight equal to 0
                catch(FormatException)
                {
                    this.weight = "0";
                    WriteLine("Weight Must Be A Number!");
                }

            }


            // Overridden toString()
            public override string ToString()
            {

                return String.Format("Name: {0}, Age: {1}, Weight: {2}\n", name, age, weight);
            }
        }


        // ----------------- Person Data Class ----------------- \\
        class PersonData
        {
            // Creates Private List 
            private List<Person> PersonList = new List<Person>();

            // addPerson Method
            // Takes in Person and Adds Person to PersonList
            public void addPerson(Person Person)
            {
                // Adds Person to List
                PersonList.Add(Person);

            }

            // printPreson Method
            // Takes in Integer called Index
            public void printPerson(int Index)
            {
                // Try/Catch Block
                try
                {
                    // Sets PersonIndex equal to PersonList[Int Index] and prints that Index Position
                    Person PersonIndex = PersonList[Index - 1]; // Index - 1 So Index Starts at 1 instead of 0
                    WriteLine(PersonIndex);

                }
                // Catches ArgumentOutOfRangeException when there is no Person in the Index Posotion being called
                catch(ArgumentOutOfRangeException)
                {
                    WriteLine("Person Does Not Exist!"); 
                }

                
            }


        }
    }
}