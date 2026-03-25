using System;

class Program
{
    static void Main(string[] args) //
    {
        //  Order 1 -
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Maria Rodriguez", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Scripture Case", "SC001", 12.99, 2));
        order1.AddProduct(new Product("CTR Ring", "CTR002", 8.50, 1));

        Console.WriteLine(order1.GetPackingLabel()); // Packing label includes product names and IDs
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

        //  Order 2
        Address address2 = new Address("45 Avenida Central", "Mexico City", "CDMX", "Mexico");
        Customer customer2 = new Customer("Carlos Hernandez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Hymn Book", "HB003", 15.00, 1));
        order2.AddProduct(new Product("Oil Vial", "OV004", 3.75, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}
