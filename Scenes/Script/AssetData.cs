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
		GD.Print("\n --- START Initialization in AssetData class ---\n");
		Departments = DataUtil.InitializeDepartmentData();
		Products = DataUtil.InitializeProductData();
		GD.Print("\n --- FINISH Initialization in AssetData class ---\n");
	}
}
