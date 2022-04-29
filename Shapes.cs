using System;

namespace Shapes
{

    // Abstract Shape Class
    abstract class Shape
    {
        // Fields/Varabiles
        private int length;
        private int width;
        private int area;

        // Getters/Setters
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Area
        {
            get { return area; }
            set { area = value; }
        }

        // Shape Constructor 
        public Shape(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        // Calcualte Area Method
        abstract public int CalcArea();
    }

    // Rectangle Inherits Shape
    class Rectangle : Shape
    {
        // Rectangle Constructor Inherits values length and width from shape
        public Rectangle(int length, int width) : base(length, width)
        {

        }

        // Calculates the Area of the Rectangle Length mutliplied by Width
        public override int CalcArea()
        {
            Area = Length * Width;
            return Area;
        }

        // Describes the Object
        public override string ToString()
        {
            string rect = String.Format("Rectangle, Length: {0} Width: {1} Area: {2}", Length, Width, Area);
            return rect;
        }

    }

    // Square
    class Square : Rectangle
    {
        // Class Constructor, Inherits from Rectangle.
        public Square(int length) : base (length, length)
        {

        }

        // Calculates the area of a square Length mutliplyed by Length

        //public override int CalcArea()
        //{
            //Area = Length * Length;
            //return Area;
        //}

        // Describes the Object
        
        public override string ToString()
        {
            string squ = String.Format("Square, Length: {0} Area: {1}", Length, Area);
            return squ;
        }
    }

    // Triangle Inherits Shape
    class Triangle : Shape
    {
        public int Height;

        public Triangle(int length, int width, int Height) : base (length, width)
        {
            this.Height = Height;
        }

        // Triangle CalcArea Length multiplyed by Height divided by 2
        public override int CalcArea()
        {
            Area = Length * Height / 2;
            return Area;
        }

        // Describes the Object
        public override string ToString()
        {
            string tri = String.Format("Triangle, Length: {0} Width: {1} Height: {2} Area {3}", Length, Width, Height, Area);
            return tri;
        }

    }

    // Main
    class Program
    {
        static void Main(string[] args)
        {
            // ShapePrinter method prints a description of the shapes
            static void ShapePrinter(Shape square)
            {
                square.CalcArea();
                Console.WriteLine(square);
            }

            // Creates an example of each object, and feeds it into ShapePrinter
            Rectangle rectangle = new Rectangle(10, 15);
            ShapePrinter(rectangle);

            Square square = new Square(10);
            ShapePrinter(square);

            Triangle triangle = new Triangle(10, 15, 12);
            ShapePrinter(triangle);

            // Change Deminsions

            // Rectangle
            rectangle.Length = 6;
            rectangle.Width = 14;

            // Square
            square.Length = 16;
            square.Width = 16;

            // Triangle
            triangle.Length = 8;
            triangle.Width = 12;
            triangle.Height = 18;

            // Feed through ShapePrinter
            Console.WriteLine("");
            ShapePrinter(rectangle);
            ShapePrinter(square);
            ShapePrinter(triangle);
        }
    }
}
