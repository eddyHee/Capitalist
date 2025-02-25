using Godot;
using System.Collections.Generic;

// Employee class
public class Employee
{
	public string EmployeeName { get; set; }
	public int Salary { get; set; }

	public Employee(string name, int salary)
	{
		EmployeeName = name;
		Salary = salary;
	}
}

// Department class
public class Department
{
	public string Name { get; set; }
	public List<Employee> Employees { get; set; } = new List<Employee>();

	public Department(string name)
	{
		Name = name;
	}

	public void AddEmployee(Employee employee)
	{
		Employees.Add(employee);
	}
}


// AssetData singleton
[GlobalClass]
public partial class AssetData : Node
{
	// Singleton instance
	private static AssetData _instance;
	public static AssetData Instance => _instance;

	// Example global data
	public int Money { get; set; } = 1000;
	public string CompanyName { get; set; } = "CAP";
	
	// Complex data: Departments and Employees
	public static List<Department> Departments { get; set; } = new List<Department>();
	public static List<Product> Products { get; set; } = new List<Product>();
	

	// Called when the node enters the scene tree
	public override void _EnterTree()
	{
		// Ensure only one instance exists
		if (_instance != null)
		{
			QueueFree(); // Destroy duplicate instances
			return;
		}
		_instance = this;
		
		// Initialize company data
		// TODO: this can be part of training process
		InitializeDepartmentData();
		InitializeProductData();
	}
	
	// Sample data initialization
	private void InitializeDepartmentData()
	{
		for (int i = 0; i < 5; i++) 
		{
			
			// Create a Sales department
			var salesDepartment = new Department("Sales");
			salesDepartment.AddEmployee(new Employee("Steve", 100));
			salesDepartment.AddEmployee(new Employee("Bob", 110));

			// Create a Marketing department
			var marketingDepartment = new Department("Marketing");
			marketingDepartment.AddEmployee(new Employee("Alice", 120));
			marketingDepartment.AddEmployee(new Employee("John", 130));

			// Add departments to the list
			Departments.Add(salesDepartment);
			Departments.Add(marketingDepartment);
		}
	}
	
	private void InitializeProductData()
	{
		// Create a new product
		var tire = new Product(
			Market.AvailableGoods.Find(g => g.Name == "Tire"), // GoodsToBuild
			CompanyName, // MadeBy
			true // is made by player
		);
		
		// Add the new product to the market
		Market.AddNewProduct(tire);
		Products.Add(tire);
		Market.PrintAvailableProducts();
	}
	
	
}
