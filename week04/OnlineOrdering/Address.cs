// The Address class stores the customer's address information.

public class Address
{
    private string _street; // Street address (e.g., "123 Main St")
    private string _city;
    private string _stateOrProvince;// State or province (e.g., "NY" for New York)
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country) // Constructor to initialize the address fields
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA() // Method to check if the address is in the USA
    {
        return _country.ToUpper() == "USA"; // Check if the country is "USA" (case-insensitive)
    }

    public string GetFullAddress() // Method to return the full address as a formatted string
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
