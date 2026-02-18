using System;

namespace GeometryProject.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override void Draw()
        {
            // Logic to render a Circle on the screen
            Console.WriteLine($"Draw a Circle with Radius: {Radius}");
        }
    }
}