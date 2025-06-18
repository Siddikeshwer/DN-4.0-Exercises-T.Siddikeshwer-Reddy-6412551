class Employee {
    int eId;
    String name;
    String position;
    double salary;

    public Employee(int eId, String name, String position, double salary) {
        this.eId = eId;
        this.name = name;
        this.position = position;
        this.salary = salary;
    }
}

class EmployeeManagement {
    private Employee[] employees;
    private int size;

    public EmployeeManagement(int capacity) {
        employees = new Employee[capacity];
        size = 0;
    }

    public void addEmployee(Employee employee) {
        if (size < employees.length) {
            employees[size] = employee;
            size++;
        }
    }

    public Employee searchEmployee(int eId) {
        for (int i = 0; i < size; i++) {
            if (employees[i].eId == eId) {
                return employees[i];
            }
        }
        return null;
    }

    public void traverse() {
        for (int i = 0; i < size; i++) {
            System.out.println(employees[i]);
        }
    }

    public void delete(int eId) {
        for (int i = 0; i < size; i++) {
            if (employees[i].eId == eId) {
                employees[i] = employees[size - 1];
                size--;
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
