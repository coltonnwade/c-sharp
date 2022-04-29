using System;
using static System.Console;
using System.Collections.Generic;


namespace Safe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiates the safe
            Safe safe1 = new Safe("1234", 30, 20, 15, 5);
            Safe safe2 = new Safe("2468", 50, 50, 50, 10);

            // Safe 1
            // Open Safe, Change Pass Code, Close Safe, Open Safe, Add Contents, Show Contents, Remove Contents, Print Safe
            WriteLine("Safe One");
            safe1.OpenSafe(); 
            safe1.ChangeAccessCode();
            safe1.CloseSafe();
            safe1.OpenSafe();

            safe1.AddContents("Keys");
            safe1.AddContents("$1000");
            safe1.AddContents("Birth Certificate");
            safe1.AddContents("Guns/Ammo");
            safe1.AddContents("Social Security Number");
            safe1.AddContents("Passport");
            string SeeItems = safe1.ShowContents();
            WriteLine(SeeItems);

            safe1.RemoveContents("Keys");
            safe1.RemoveContents("$1000");
            safe1.RemoveContents("Passport");
            WriteLine(safe1);

            // safe 2
            // Change Pass Code, Add Items, print safe, Change Values, Remove Contents, Print Safe,
            WriteLine("\nSafe Two");
            safe2.ChangeAccessCode();

            SeeItems = safe2.ShowContents();
            WriteLine(SeeItems);
            safe2.AddContents("Gold");

            WriteLine(safe2);
            safe2.Height = 10;
            safe2.Width = 10;
            safe2.Depth = 5;
            safe2.Shelves = 0;
            safe2.Shelves = 1;
            WriteLine(safe2);

            safe2.RemoveContents("Gold");

            safe2.OpenSafe();
            safe2.AddContents("Gold");
            WriteLine(safe2);
            
        }
    }

    // Safe Class

    class Safe
    {
        //_________________________Fields/Variables_________________________\\
        private bool isOpen = false;
        private string accessCode = "";
        private int shelves;
        private int height;
        private int width;
        private int depth;
        List<string> contents = new List<string>();

        

        //_________________________Class Methods_________________________\\

        //changeAccessCode
        // Changes Access Code too Safe. If you enter the current access code correct you can change the access code, if you do not enter the current
        // access code correct it will show an error. 
        public string ChangeAccessCode()
        {
            string code;
            string newAccessCode;
            Write("\nEnter Current Access Code: ");
            code = ReadLine();

            if (accessCode == code)
            {
                Write("Enter New Access Code: ");
                newAccessCode = ReadLine();

                accessCode = newAccessCode;
            }
            else
            {
                WriteLine("Code is Invalid!");
            }
            return accessCode;
        }

        //Be sure to verify the operation of the safe:
        //You shouldn't be able to close the safe if it's already closed.
        //You shouldn't be able to open the safe if the safe is already open.

        //openSafe
        // You can only open the safe by entering the correct access code it will say "Safe Unlocked!." You cannot open the safe it is already open.
        // If you enter the access code incorrect it will show an error.
        public bool OpenSafe()
        {
            string code;
            Write("Enter Access Code to Unlock: ");
            code = ReadLine();

            if (code == accessCode)
            {
                if (isOpen == true)
                {
                    WriteLine("Safe is already open"); // This will show in console if safe is already open and you try to open it
                }
                else
                {
                    isOpen = true;
                    WriteLine("Safe Unlocked!");
                }
            }
            else
            {
                WriteLine("Access Code is Incorrect!");
                isOpen = false;
            }
            return isOpen;
            
            
        }

        //closeSafe
        // It will ask if you want to close the safe, if you answer with y it will choose the safe, if you do not answer with y it will not close the safe.
        // You cannot close the safe if it is already closed, if you close the safe it will say "Safe Locked!" 
        public bool CloseSafe()
        {

            string choice;
            Write("\nDo you want to close the Safe? (y/n): ");
            choice = ReadLine();
            if (choice == "y")
                if (isOpen == false)
                {
                    WriteLine("Safe is already closed"); // This will show in console if the safe is closed and you try to close it
                }
                else
                {
                    isOpen = false;
                    WriteLine("Safe Locked!");
                }
            return isOpen;
        }

        //showContents
        // This will return the list of contents only if the safe is open. It will show an error if you try and see what's inside while locked.
        // If there isnt anything inside it will say "Contents: empty"
        public string ShowContents()
        {
            string items = null;
            if (isOpen == true)
            {
                if (contents.Count != 0)
                    items = "\nContents: " + string.Join(", ", contents);
                else
                    items = "\nContents: empty";
            }
        
            else
            {
                WriteLine("You must enter the secret passcode to see what's inside!!");
            }

            return items;
        }

        //addContents
        // You can only add contents to the safe if the safe is open, if the safe is not open it will prompt an error message.
        public string AddContents(string item)
        {
            if (isOpen == true)
            {
                contents.Add(item);
                
            }
            else
            {
                WriteLine("Cannot Add Items when Safe is Locked!");
            }
            return item;
        }

        //removeContents
        // You can only remove contents inside the safe if the safe is open, if the safe is not open it will prompt an error message.
        public string RemoveContents(string item)
        {
            if (isOpen == true)
            {
                contents.Remove(item);
            }
            else
            {
                WriteLine("Cannot Remove Items when Safe is Locked");
            }
            return item;
        }

        // Class Constructor
        public Safe(string accessCode, int height, int width, int depth, int shelves)
        {
            this.accessCode = accessCode;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.shelves = shelves;

        }

        //_________________________Getters and Setters_________________________\\

        // gets isOpen
        public bool Open
        {
            get { return isOpen; }
        }

        // get/set Height
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        // get/set Width
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        // get/set Depth
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        // get/set Shelves
        public int Shelves
        {
            get { return shelves; }
            set
            {
                if (value <= 0) // If you try to set the value of shelves to negative or 0, it will prompt an error message, and keep the default value.
                    WriteLine("Must have shelves");
                else
                    shelves = value;
            }
        }


        // Override to String
        // This was not required, but I really thought about how to make this act like a real safe and I feel like this was the best way for me to do that.
        // If the safe is locked you can only see the height/width/depth, and if the safe is open/locked. So it will only return that information.
        // If the safe is unlocked and there are contents in the safe it will return height, width, depth, contents ,shelves, and if the safe is open/locked.
        // If the safe is unlocked and there aren't any contents, it will return everything except the contents. It will return "The safe is empty!"
        public override string ToString()
        {
            string result;
            string status;

            if (isOpen == true)
            {
                status = "Open";
                if (contents.Count == 0)
                {
                    result = String.Format("\nThe safe is {0} high, {1} wide, and {2} deep. The safe is empty! The safe has {3} shelves. The safe is {4}",
                       height, width, depth, shelves, status);
                }
                else
                {
                    result = String.Format("\nThe safe is {0} high, {1} wide, and {2} deep. The safe contains {3}. The safe has {4} shelves. The safe is {5}",
                       height, width, depth, string.Join(", ", contents), shelves, status);
                }
 
            }
            else
            {
                status = "Locked";
                result = String.Format("\nThe safe is {0} high, {1} wide, and {2} deep. The safe is {3}", height, width, depth, status);

            }

            return result;
        }


    }
}

