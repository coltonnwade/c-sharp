using System;
using System.Linq;
using static System.Console;

namespace SportsPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

        
            
            BasketballPlayer Mike = new BasketballPlayer("Mike", 21, 120000, 97.99m, 8765, 7638, 12039); // name, age, salary, freethrowaverage, freethrowshots, threepointshot, twopointshots
            BasketballPlayer John = new BasketballPlayer("John", 25, 790000, 87.96m, 8000, 7000, 14000);
            BasketballPlayer Ron = new BasketballPlayer("Ron", 32, 780000, 96.76m, 12000, 11500, 16000);
        
            BaseballPlayer Travis = new BaseballPlayer("Travis", 19, 800000.76m, 87.94m, 2700, 102); // name, age, salary, battingaverage, homeruns, errors
            BaseballPlayer Larry = new BaseballPlayer("Larry", 24, 700000.50m, 92.34m, 2864, 83);
            BaseballPlayer Brock = new BaseballPlayer("Brock", 24, 764239.50m, 91.54m, 3424, 92);

            // Creates Array of Objects
            BasketballPlayer[] Basketball  = { Mike, John, Ron };

            // Finds Highest Salary
            decimal highest = Basketball[0].Salary;
            for (int i = 0; i < Basketball.Length; i++)
            {
                if (Basketball[i].Salary > highest)
                    highest = Basketball[i].Salary;
                
            }
            WriteLine(highest);
            

            BaseballPlayer[] Baseball = { Travis, Larry, Brock };
            for (int i = 0; i < Baseball.Length; i++)
            {
                //WriteLine(Baseball[i] + "\n");
            }

        }
    }

    // Sports Player
    class SportsPlayer
    {
        // Variables
        protected string name;
        protected int age;
        protected decimal salary;

        // Getter for Salary so I can use it in main
        public decimal Salary
        {
            get { return salary; }
        }

        // SportsPlayer Constructor
        public SportsPlayer(string name, int age, decimal salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        // To String
        public override string ToString() => String.Format("Name: {0} \nAge: {1} \nSalary: {2}", name, age, salary);


    }

    // Basketball Player
    class BasketballPlayer : SportsPlayer
    {
        // Variables
        private decimal freeThrowAverage;
        private int freeThrowShots;
        private int threePointShots;
        private int twoPointShots;

        // BasketballPlayer Constructor
        public BasketballPlayer(string name, int age, decimal salary,
            decimal freeThrowAverage, int freeThrowShots, int threePointShots, int twoPointShots) : base(name, age, salary)
        {
            this.freeThrowAverage = freeThrowAverage;
            this.freeThrowShots = freeThrowShots;
            this.threePointShots = threePointShots;
            this.twoPointShots = twoPointShots;
        }

        // To String
        public override string ToString() => String.Format("Name: {0} \nAge: {1} \nSalary: {2} \nFree Throw Average: {3} \nFree Throw Shots: {4}" +
            " \nThree Point Shots: {5} \nTwoPointShots: {6}", name, age, salary, freeThrowAverage, freeThrowShots, threePointShots, twoPointShots);

    }

    // BaseballPlayer
    class BaseballPlayer:SportsPlayer
    {
        // Variables
        private decimal battingAverage;
        private int homeRuns;
        private int errors;


        // BaseballPlayer Constructor
        public BaseballPlayer(string name, int age, decimal salary, decimal battingAverage, int homeRuns, int errors) : base(name, age, salary)
        {
            this.battingAverage = battingAverage;
            this.homeRuns = homeRuns;
            this.errors = errors;
        }

        // To String
        public override string ToString() => String.Format("Name: {0} \nAge: {1} \nSalary: {2} \nBatting Average: {3} \nHome Runs: {4} \nErrors: {5}",
            name, age, salary, battingAverage, homeRuns, errors);
    }
}
