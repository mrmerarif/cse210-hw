// The Order class stores products and a customer, and calculates totals.

using System;
using System.Collections.Generic;  // For List<T>

public class Order
{
    private List<Product> _products = new List<Product>(); // List to hold products in the order
    private Customer _customer; // Customer associated with the order

    public Order(Customer customer)  // Constructor to initialize the order with a customer
    {
        _customer = customer;
    }

    public void AddProduct(Product product)  //
    {
        _products.Add(product);
    }

    public double GetTotalCost() // Method to calculate the total cost of the order, including shipping
    {
        double total = 0;

        foreach (Product product in _products) // Loop through each product and add its total cost to the overall total
        {
            total += product.GetTotalCost(); // GetTotalCost() is a method of the Product class that calculates the cost of that product (price * quantity)
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35; // Determine shipping cost based on whether the customer lives in the USA or not

        return total + shipping;  // Return the total cost of the order, including shipping
    }

    public string GetPackingLabel() //
    {
        string label = "Packing Label:\n"; // Start the packing label with a header

        foreach (Product product in _products)  // Loop through each product and add its packing label line to the overall label
        {
            label += $"- {product.GetPackingLabelLine()}\n";  // GetPackingLabelLine() is a method of the Product class that returns a string with the product's name and quantity, formatted for the packing label
        }

        return label;
    }

    public string GetShippingLabel()  //
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddressString()}"; // Return the shipping label, which includes the customer's name and address. GetName() and GetAddressString() are methods of the Customer class that return the customer's name and a formatted string of their address, respectively.
    }
}
