using System;  // Needed for Console.WriteLine and Math.PI
using System.Collections.Generic; // Main program to test the Shape classes and demonstrate polymorphism    

class Program
{
    static void Main(string[] args) //
    {
        Console.WriteLine("Shapes Project");
        Console.WriteLine("--------------\n");

        //
        Square square = new Square("Red", 5); // Create a Square object with color "Red" and side length 5
        Console.WriteLine($"Square Color: {square.GetColor()}"); // Output the color of the square using the GetColor method inherited from Shape
        Console.WriteLine($"Square Area: {square.GetArea()}\n"); // Output the area of the square using the overridden GetArea method in Square

        // Test Rectangle
        Rectangle rectangle = new Rectangle("Blue", 4, 6); // Create a Rectangle object with color "Blue", width 4, and height 6
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}"); // Output the color of the rectangle using the GetColor method inherited from Shape
        Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}\n"); // Output the area of the rectangle using the overridden GetArea method in Rectangle

        // Test Circle
        Circle circle = new Circle("Green", 3); // Create a Circle object with color "Green" and radius 3
        Console.WriteLine($"Circle Color: {circle.GetColor()}");
        Console.WriteLine($"Circle Area: {circle.GetArea()}\n");

        // Polymorphism List
        Console.WriteLine("Polymorphism List Output:"); // Output header for the polymorphism demonstration
        Console.WriteLine("-------------------------");

        List<Shape> shapes = new List<Shape>(); // Create a list of Shape objects to demonstrate polymorphism
        shapes.Add(square); // Add the square object to the list
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes) // Iterate through each shape in the list and output its color and area using the GetColor and GetArea methods, demonstrating polymorphism
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}\n"); // Output the color and area of each shape, demonstrating that the correct GetArea method is called for each shape type due to polymorphism
        }
    }
}
