// The Product class stores product details and calculates total cost.

public class Product
{
    private string _name;  // Product name
    private string _productId;  // Unique product identifier (e.g., "P12345")
    private double _pricePerUnit; // Price per unit of the product
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity) // Constructor to initialize the product fields

    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public double GetTotalCost() //
    {
        return _pricePerUnit * _quantity; // Calculate total cost by multiplying price per unit by quantity
    }

    public string GetPackingLabelLine() // Method to return a packing label line for the product, including the product name and ID
    {
        return $"{_name} (ID: {_productId})"; // Format the packing label line with the product name and ID
    }
}
