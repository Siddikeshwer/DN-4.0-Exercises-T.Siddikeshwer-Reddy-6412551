using System;

// Employee.cs
public class Employee
{
    public int EId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int eId, string name, string position, double salary)
    {
        EId = eId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Position = position ?? throw new ArgumentNullException(nameof(position));
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Employee{{EId={EId}, Name={Name}, Position={Position}, Salary={Salary}}}";
    }
}

// EmployeeManagement.cs
public class EmployeeManagement
{
    private readonly Employee[] _employees;
    private int _size;

    public EmployeeManagement(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException("Capacity must be non-negative.", nameof(capacity));
        _employees = new Employee[capacity];
        _size = 0;
    }

    public void AddEmployee(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee));
        if (_size < _employees.Length)
        {
            _employees[_size] = employee;
            _size++;
        }
    }

    public Employee SearchEmployee(int eId)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_employees[i].EId == eId)
            {
                return _employees[i];
            }
        }
        return null;
    }

    public void Traverse()
    {
        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine(_employees[i]);
        }
    }

    public void Delete(int eId)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_employees[i].EId == eId)
            {
                _employees[i] = _employees[_size - 1];
                _employees[_size - 1] = null;
                _size--;
                break;
            }
        }
    }
}

/*
COMPLEXITY:
Add Operation: O(1)
Search Operation: O(n)
Traverse Operation: O(n)
Delete Operation: O(n)
*/
