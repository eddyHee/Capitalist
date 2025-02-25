using Godot;
using System.Collections.Generic;

public class Market
{
	public List<Good> AvailableGoods { get; set; }
	public List<Product> AvailableProducts { get; set; }

	public Market()
	{
		// Initialize default goods
		AvailableGoods = CreateDefaultGoods();
		// Initialize default products
		AvailableProducts = CreateDefaultProducts();
	}

	private List<Good> CreateDefaultGoods()
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
	
	private List<Product> CreateDefaultProducts()
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

	// Method to print all available goods
	public void PrintAvailableGoods()
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
}
