using Godot;
using System.Collections.Generic;

public static class Market
{
	public static List<Good> AvailableGoods { get; set; }
	public static List<Product> AvailableProducts { get; set; }

	static Market()
	{
		// Initialize default goods
		AvailableGoods = CreateDefaultGoods();
		// Initialize default products
		AvailableProducts = CreateDefaultProducts();
	}

	private static List<Good> CreateDefaultGoods()
	{
		// Create basic goods (no required goods)
		var metal = new Good("Metal", 2, null);
		var rubber = new Good("Rubber", 5, null);

		// Create intermediate goods (require basic goods)
		var tire = new Good("Tire", 20, new List<Good> { rubber });
		var battery = new Good("Battery", 10, new List<Good> { metal });

		// Create advanced goods (require intermediate goods)
		var car = new Good("Car", 100, new List<Good> { tire, battery });

		// Add all goods to the list
		return new List<Good> { metal, rubber, tire, battery, car };
	}
	
	private static List<Product> CreateDefaultProducts()
	{
		// Create basic product (no required goods)
		var metal = new Product(
			AvailableGoods.Find(g => g.Name == "Metal"), 
			"Metal specialist", 
			10, 
			20, 
			2
		);
		var rubber = new Product(
			AvailableGoods.Find(g => g.Name == "Rubber"), 
			"Metal specialist", 
			10, 
			20, 
			2
		);


		// Add all goods to the list
		return new List<Product> { metal, rubber };
	}
	
	public static void AddNewProduct(Product product)
	{
		if (product == null)
		{
			GD.PrintErr("Cannot add a null product.");
			return;
		}

		// Check if the product already exists in the list
		// TODO: avoid add same product made by same company
		//if (AvailableProducts.Contains(product))
		//{
			//GD.PrintErr($"Product '{product.GoodsToBuild.Name}' already exists in the market.");
			//return;
		//}

		// Add the product to the list
		AvailableProducts.Add(product);
		GD.Print($"Added new product: {product.Good.Name}");
	}

	// Method to print all available goods
	public static void PrintAvailableGoods()
	{
		foreach (var goods in AvailableGoods)
		{
			GD.Print($"Goods: {goods.Name}, Time to Build: {goods.BasicTimeToBuild}");
			if (goods.GoodsRequired.Count > 0)
			{
				GD.Print("Required Goods:");
				foreach (var requiredGood in goods.GoodsRequired)
				{
					GD.Print($"- {requiredGood.Name}");
				}
			}
			else
			{
				GD.Print("No required goods.");
			}
			GD.Print("---");
		}
	}
	
	public static void PrintAvailableProducts()
	{
		foreach (var product in AvailableProducts)
		{
			GD.Print($"Product: {product.Good.Name}");
			GD.Print($"Made By: {product.MadeBy}");
			//GD.Print($"Cost to Build: {product.CostToBuild}");
			//GD.Print($"Time to Build: {product.TimeToBuild}");
			//GD.Print($"Current Quantities: {product.CurrentQuantities}");
			GD.Print("---");
		}
	}
}
