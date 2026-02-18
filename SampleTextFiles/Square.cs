using System;

namespace GeometryProject.Shapes
{
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override void Draw()
        {
            // Perform the Draw action for the Square
            Console.WriteLine($"Draw a Square with Side: {SideLength}");
        }
    }
}