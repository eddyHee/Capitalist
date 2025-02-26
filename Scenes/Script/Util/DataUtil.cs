using Godot;
using System.Collections.Generic;

public static class DataUtil
{
	// Initialize department data
	public static List<Department> InitializeDepartmentData()
	{
		GD.Print("\tInitialize department data...");

		// Create a Sales department
		var salesDepartment = new Department("Sales");
		salesDepartment.AddEmployee(new Employee("Steve", 100));
		salesDepartment.AddEmployee(new Employee("Bob", 110));

		// Create a Marketing department
		var marketingDepartment = new Department("Marketing");
		marketingDepartment.AddEmployee(new Employee("Alice", 120));
		marketingDepartment.AddEmployee(new Employee("John", 130));

		// Create a Production department
		var productionDepartment = new Department("Production");
		productionDepartment.AddEmployee(new Employee("Alex", 120));
		productionDepartment.AddEmployee(new Employee("John", 130));

		// Add departments to the list
		var departments = new List<Department>
		{
			salesDepartment,
			marketingDepartment,
			productionDepartment
		};

		return departments;
	}

	// Initialize product data
	public static List<Product> InitializeProductData()
	{
		GD.Print("\tInitialize product data...");

		var products = new List<Product>();

		// Create a new product: Tire
		var tire = new Product(
			Market.AvailableGoods.Find(g => g.Name == "Tire"), // GoodsToBuild
			AssetData.Instance.CompanyName, // MadeBy
			true // is made by player
		);
		tire.AddMaterialRequirement(Market.GetProductByName("Rubber"), 1, 12, true);
		Market.AddNewProduct(tire);
		products.Add(tire);

		// Create a new product: Battery
		var battery = new Product(
			Market.AvailableGoods.Find(g => g.Name == "Battery"), // GoodsToBuild
			AssetData.Instance.CompanyName, // MadeBy
			true // is made by player
		);
		battery.AddMaterialRequirement(Market.GetProductByName("Metal"), 1, 12, true);
		battery.AddMaterialRequirement(Market.GetProductByName("Rubber"), 1, 12, true);
		battery.AddMaterialRequirement(Market.GetProductByName("Tire"), 1, 12, true);
		Market.AddNewProduct(battery);
		products.Add(battery);

		// Create a new product: Car
		var car = new Product(
			Market.AvailableGoods.Find(g => g.Name == "Car"),
			AssetData.Instance.CompanyName,
			true
		);
		car.AddMaterialRequirement(Market.GetProductByName("Tire"), 1, 14, true);
		tire.AddMaterialRequirement(Market.GetProductByName("Metal"), 1, 12, true);
		Market.AddNewProduct(car);
		products.Add(car);

		// Print available products
		Market.PrintAvailableProducts();

		return products;
	}
}
