namespace GeometryProject.Core
{
    // Base class for all geometric entities
    public abstract class Shape
    {
        public string ShapeName { get; set; }

        /// <summary>
        /// Abstract method to Draw the specific shape
        /// </summary>
        public abstract void Draw();
    }
}