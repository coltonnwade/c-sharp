using System;
using static System.Console;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instansiates Person
            Person Mike = new Person("Mike Jones", "fifteen", 162);
            Person Colton = new Person("Colton Wade", "19", 150);
            Person Steve = new Person("Steve George", "34", 220);
            Person Chris = new Person("Chris Evans", "40", 205);
            Person Ryan = new Person("Ryan Reynolds", "44", 200);
            Person Blake  = new Person("Blake Lively", "34", 120);


            // Creates a list of People (Object Person)
            Person[] People = { Mike, Colton, Steve, Chris, Ryan, Blake };


            // While True Loop calls UserInput and QueryPersonList method, if QueryPersonList returns null
            // It will continue the loop until user enters a correct IndexPosition of a Person
            while (true) 
            {
                int userInput = UserInput();
                Person result = QueryPersonList(People, userInput);
                
                // if result returns null it will continue the loop, if it doesnt return null
                // it will break the loop and print the result
                if (result == null)
                {
                    continue;
                }
                else
                {
                    WriteLine(result);
                    break;
                }
            }

        }

        // Asks user to input Index Position of Person and validates/stores user input in int input
        public static int UserInput()
        {
            
            string IndexPos;

            // While Loop that continues until user inputs valid data
            while (true)
            {
                // Ask user to input index position
                Write("Enter Number of Person: ");
                IndexPos = ReadLine(); // store user input in string input

                // Try/Catch to convert input to int, incase user enters something other than an int.
                try
                {
                    // Converts input to int, if input is less than 0 it will continue
                    // to to ask user for valid input and print an error message
                   
                    if (Convert.ToInt32(IndexPos) < 0) 
                    {
                        WriteLine("Must be an Integer Above 0!");
                        continue; 
                    }
                    else
                    {
                        break; 
                    }
                }
                // Catches error and prints error message
                catch (FormatException)
                {
                    WriteLine("Input Must Be An Integer!\n"); 
                    continue; 
                }
             }
            // Returns input
            return Convert.ToInt32(IndexPos);
        }


        // Loops through the People Array until it finds the user inputted Index Position, then prints the person. 
        public static Person QueryPersonList(Person[] People, int IndexPos)
        {

            // Loops through People array
            Person IndexPerson = People[0];
            for (int i = 0; i < People.Length; i++)
            {
                
                try
                {
                    // If the person is equal to the index position entered in UserInput
                    // Then that perrson will set equal to IndexPerson
                    if (People[i] == People[IndexPos])
                        IndexPerson = People[i - 1]; // [i -1] so the index doesnt start at 0.

                }
                catch (IndexOutOfRangeException)
                {
                    // If input from UserInput exceeds the number of people in the list, it will return null with an error
                    WriteLine("Person does not exist!");
                    return null;

                }
                
            }
            // Returns IndexPerson
            return IndexPerson;

        }
    }

    // Person Class
    class Person
    {
        // Instance Variables 
        private string name;
        private string age;
        private decimal weight;

        // Class Contructor
        // Converts age to int 
        public Person(string name, string age, decimal weight)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;

            // Converts age from String to Int, conversion fails age will be set to 0
            try
            { 
                int.Parse(age);
            }
            // If age is a deciaml or string, it will catch the exception thrown.
            catch (FormatException)
            {
                // Sets age equal to 0, if converting age to int fails.
                this.age = "0";
            }
        }
                       

        // Overridden toString()
        public override string ToString()
        {

            return String.Format("\nName: {0}, Age: {1}, Weight: {2}", name, age, weight);
        } 
    }
}
