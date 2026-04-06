using System; // Needed for Math.PI

public class Rectangle : Shape // Rectangle class inherits from Shape
{
    private double _length; // Private field to store the length of the rectangle
    private double _width;

    public Rectangle(string color, double length, double width) : base(color) // Constructor that takes color, length, and width, and calls the base class constructor for color
    {
        _length = length; // Initialize the length field
        _width = width; // Initialize the width field
    }

    public override double GetArea()  // Override the GetArea method to calculate the area of the rectangle
    {
        return _length * _width;
    }
}
