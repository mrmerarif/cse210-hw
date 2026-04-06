using System; // Square class inherits from Shape and represents a square shape with a specific side length

public class Square : Shape // Square class definition
{
    private double _side; // Private field to store the length of the side of the square

    public Square(string color, double side) : base(color) // Constructor that takes color and side length, and calls the base class constructor for color
    {
        _side = side;
    }

    public override double GetArea() // Override the GetArea method to calculate the area of the square
    {
        {
            return _side * _side;
        }
    }
