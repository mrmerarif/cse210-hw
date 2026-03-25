// The Customer class stores the customer's name and address.

public class Customer
{
    private string _name; // Customer's name
    private Address _address;

    public Customer(string name, Address address) // Constructor to initialize the customer's name and address
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()  // Method to check if the customer lives in the USA by calling the IsInUSA method of the Address class
    {
        return _address.IsInUSA();
    }

    public string GetName()  // Method to return the customer's name
    {
        return _name;
    }

    public string GetAddressString() // Method to return the customer's full address as a string by calling the GetFullAddress method of the Address class

    {
        return _address.GetFullAddress();
    }
}
