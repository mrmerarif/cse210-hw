using System; // Needed for Math.PI

public class Circle : Shape // Circle class inherits from Shape
{
    private double _radius; // Private field to store the radius of the circle

    public Circle(string color, double radius) : base(color) // Constructor that takes color and radius, and calls the base class constructor for color
    {
        _radius = radius; // Initialize the radius field
    }

    public override double GetArea() // Override the GetArea method to calculate the area of the circle
    {
        return Math.PI * _radius * _radius;
    }
}
