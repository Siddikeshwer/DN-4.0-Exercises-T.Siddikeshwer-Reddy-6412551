import java.util.HashMap;
import java.util.Map;

interface CustomerRepository {
    Customer findCustomerById(int id);
}

class CustomerRepositoryImpl implements CustomerRepository {
    private Map<Integer, Customer> customerDatabase;
    
    public CustomerRepositoryImpl() {
        customerDatabase = new HashMap<>();
        customerDatabase.put(1, new Customer(1, "John Doe"));
        customerDatabase.put(2, new Customer(2, "Jane Smith"));
    }
    
    @Override
    public Customer findCustomerById(int id) {
        return customerDatabase.get(id);
    }
}

class CustomerService {
    private CustomerRepository customerRepository;
    
    public CustomerService(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }
    
    public Customer getCustomerById(int id) {
        return customerRepository.findCustomerById(id);
    }
}

class Customer {
    private int id;
    private String name;
    
    public Customer(int id, String name) {
        this.id = id;
        this.name = name;
    }
    
    public int getId() {
        return id;
    }
    
    public String getName() {
        return name;
    }
    
    @Override
    public String toString() {
        return "Customer{id=" + id + ", name='" + name + "'}";
    }
}

public class DependencyInjectionTest {
    public static void main(String[] args) {
        CustomerRepository customerRepository = new CustomerRepositoryImpl();
        CustomerService customerService = new CustomerService(customerRepository);
        
        Customer customer = customerService.getCustomerById(1);
        System.out.println(customer);
        
        Customer anotherCustomer = customerService.getCustomerById(2);
        System.out.println(anotherCustomer);
    }
}