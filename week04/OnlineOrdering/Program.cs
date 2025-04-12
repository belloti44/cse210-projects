using System;
using System.Collections.Generic;

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {_name}, ID: {_productId}";
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"Name: {_name}\nAddress:\n{_address.GetFullAddress()}";
    }
}

class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // First order - USA
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LTP123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 25.50, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine("---------------------------------------");

        // Second order - international
        Address address2 = new Address("42 High Street", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Alice Brown", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "SPH789", 750.00, 1));
        order2.AddProduct(new Product("Charger", "CHR101", 20.00, 2));
        order2.AddProduct(new Product("Case", "CSE202", 15.00, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
    }
}