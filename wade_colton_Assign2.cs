using System;

namespace ProgrammingClass
{
    class Program
    {
        static void Main(string[] args)
        {

         // Declares Arrays //

            string[] airlines = {"American", "Delta", "Spirit", "United", "Spirit", "Delta", "United", "Southwest", "Southwest"};
            int[] flightNums = {800, 565, 892, 1844, 1544, 2844, 542, 899, 1313};
            string[] from = {"Nashville", "Atlantic City", "Los Angeles", "Nashville", "Chicago", "Atlanta", "Chicago", "Las Vegas", "Boston"};
            int[] gates = { 3, 4, 1, 4, 12, 2, 1, 3, 6 };


         // Call's First Overloaded Method //

            string flightResults = flightFinder(airlines, flightNums, from, gates); 
            Console.WriteLine(flightResults); // Outputs Result


         // Call's Second Overloaded Method //
         
            string airline = "Southwest";                           
            flightResults = flightFinder(airlines, flightNums, from, gates, airline);

            // Checks to see if Results were Found
            if (flightResults == null)
            {
                Console.WriteLine("No Results\n"); // If no results were found it will output No Results
            }
            else
            {
                Console.WriteLine(flightResults); // If results were found it will output the results
            }


         // Call's Third Overloaded Method //

            airline = "Delta";
            int flight = 800;
            flightResults = flightFinder(airlines, flightNums, from, gates, airline, flight);

            // Checks to see if Results were Found
            if (flightResults == null)
            {
                Console.WriteLine("No Results\n"); // If no results were found it will output No Results
            }
            else
            {
                Console.WriteLine(flightResults); // If results were found it will output the results
            }



          // Call's Fourth Overloaded Method //

            int gate = 3;
            flightResults = flightFinder(airlines, flightNums, from, gates, gate);

            // Checks to see if Results were Found
            if (flightResults == null)
            {
                Console.WriteLine("No Results\n"); // If no results were found it will output No Results
            }
            else
            {
                Console.WriteLine(flightResults); // If results were found it will output the results
            }

        }


        // returns string of all airlines
         public static string flightFinder(string[] airlines, int[] flightNums, string[] from, int[] gates)
         {
          string results = "";

            // Loops through FlightNums and appends a formatted string of all flights stored in string results.
            for (int i = 0; i < flightNums.Length; i++)
            {  
                results += string.Format("Flight: {0} {1} From: {2} Gate: {3}\n", airlines[i], flightNums[i], from[i], gates[i]);
            }
            return results;

         }



        // Filter by airlines
        public static string flightFinder(string[] airlines, int[] flightNums, string[] from, int[] gates, string airline)
        {
            string results = "";
            for (int i = 0; i < flightNums.Length; i++)
            {
                // Searches for string airline in airlines[], and appends it to results.
                if (airlines[i].Equals(airline))
                {
                    results += string.Format("Flight {0} {1} From: {2} Gate: {3}\n", airlines[i], flightNums[i], from[i], gates[i]);
                }
            }
            // If no results are found, it will return null.
            if (results == string.Empty)
            {
                return null;
            }

            // Returns string results
            return results;
        }



        //Filter by airlines and gate
        public static string flightFinder(string[] airlines, int[] flightNums, string[] from, int[] gates, string airline, int flight)
        {
            string results = "";
            for (int i = 0; i < flightNums.Length; i++)
            {
                // Searches through airlines[], and flightnms[], for int flight and string airline, it will append the results to string results.
                if (flightNums[i].Equals(flight) || (airlines[i].Equals(airline)))
                {
                    results += string.Format("Flight {0} {1} From: {2} Gate: {3}\n", airlines[i], flightNums[i], from[i], gates[i]);
                }
            }

            if (results == string.Empty)
            {
                return null;
            }

            return results;
        }



        // Filter airlines by gate
        public static string flightFinder(string[] airlines, int[] flightNums, string[] from, int[] gates, int gate)
        {
            string results = "";
            for (int i = 0; i < flightNums.Length; i++)
            {
                // Searches through gates[] for int gate, then appends results to string results.
                if (gates[i].Equals(gate))
                {
                    results += string.Format("Flight {0} {1} From: {2} Gate: {3}\n", airlines[i], flightNums[i], from[i], gates[i]);
                }
            }
            if (results == string.Empty)
            {
                return null;
            }

            return results;
        }



    }
}

