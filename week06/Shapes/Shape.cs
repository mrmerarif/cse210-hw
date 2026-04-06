using System; // Base class for all shapes, containing common properties and methods 

public class Shape // Shape class definition
{
    private string _color; // Private field to store the color of the shape

    public Shape(string color) // Constructor that takes a color parameter and initializes the _color field
    {
        _color = color;
    }

    public string GetColor() // Method to get the color of the shape
    {
        return _color;
    }

    public void SetColor(string color) // Method to set the color of the shape
    {
        _color = color;
    }


    public virtual double GetArea() // Virtual method to calculate the area of the shape, which can be overridden by derived classes
    {
        return 0;
    }
}
