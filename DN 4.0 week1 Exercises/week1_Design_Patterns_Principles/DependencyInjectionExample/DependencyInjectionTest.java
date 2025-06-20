using System;
using System.Collections.Generic;

// ICustomerRepository.cs
public interface ICustomerRepository
{
    Customer FindCustomerById(int id);
}

// CustomerRepositoryImpl.cs
public class CustomerRepositoryImpl : ICustomerRepository
{
    private readonly Dictionary<int, Customer> _customerDatabase;

    public CustomerRepositoryImpl()
    {
        _customerDatabase = new Dictionary<int, Customer>
        {
            { 1, new Customer(1, "John Doe") },
            { 2, new Customer(2, "Jane Smith") }
        };
    }

    public Customer FindCustomerById(int id)
    {
        _customerDatabase.TryGetValue(id, out var customer);
        return customer;
    }
}

// CustomerService.cs
public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public Customer GetCustomerById(int id)
    {
        return _customerRepository.FindCustomerById(id);
    }
}

// Customer.cs
public class Customer
{
    private readonly int _id;
    private readonly string _name;

    public Customer(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public int Id => _id;

    public string Name => _name;

    public override string ToString()
    {
        return $"Customer{{id={_id}, name='{_name}'}}";
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        ICustomerRepository customerRepository = new CustomerRepositoryImpl();
        CustomerService customerService = new CustomerService(customerRepository);

        Customer customer = customerService.GetCustomerById(1);
        Console.WriteLine(customer);

        Customer anotherCustomer = customerService.GetCustomerById(2);
        Console.WriteLine(anotherCustomer);
    }
}
