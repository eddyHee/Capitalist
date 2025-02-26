using Godot;
using System.Collections.Generic;

public static class Market
{
	public static List<Good> AvailableGoods { get; private set; }
	public static List<Product> AvailableProducts { get; private set; }

	static Market()
	{
		GD.Print("\n=== Market Initialization ===\n");

		// Initialize default goods
		GD.Print(">> Creating Default Goods...");
		AvailableGoods = CreateDefaultGoods();
		GD.Print(">> Default Goods Created.\n");
		PrintAvailableGoods();
		GD.Print("\n>> Finished Printing Default Goods.\n");

		// Initialize default products
		GD.Print(">> Creating Default Products...");
		AvailableProducts = CreateDefaultProducts();
		GD.Print(">> Default Products Created.\n");
		PrintAvailableProducts();
		GD.Print("\n>> Finished Printing Default Products.\n");

		GD.Print("=== Market Initialization Complete ===\n");
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
			"Rubber specialist",
			10,
			20,
			2
		);

		// Add all products to the list
		return new List<Product> { metal, rubber };
	}

	/// <summary>
	/// Adds a new product to the market.
	/// </summary>
	public static void AddNewProduct(Product product)
	{
		if (product == null)
		{
			GD.PrintErr("ERROR: Cannot add a null product.");
			return;
		}

		// Check if the product already exists in the list
		if (AvailableProducts.Contains(product))
		{
			GD.PrintErr($"ERROR: Product '{product.Name}' already exists in the market.");
			return;
		}

		// Add the product to the list
		AvailableProducts.Add(product);
		GD.Print($"SUCCESS: Added new product: {product.Name}");
	}

	/// <summary>
	/// Finds the first product with the specified name.
	/// </summary>
	public static Product GetProductByName(string name)
	{
		return AvailableProducts.Find(p => p.Name == name);
	}

	/// <summary>
	/// Prints all available goods.
	/// </summary>
	public static void PrintAvailableGoods()
	{
		GD.Print("\n=== Available Goods ===\n");
		foreach (var goods in AvailableGoods)
		{
			GD.Print($"Goods: {goods.Name}");
			GD.Print($"- Time to Build: {goods.BasicTimeToBuild}");
			if (goods.GoodsRequired != null && goods.GoodsRequired.Count > 0)
			{
				GD.Print("- Required Goods:");
				foreach (var requiredGood in goods.GoodsRequired)
				{
					GD.Print($"  - {requiredGood.Name}");
				}
			}
			else
			{
				GD.Print("- No required goods.");
			}
			GD.Print("---\n");
		}
		GD.Print("\n=== End of Available Goods ===\n");
	}

	/// <summary>
	/// Prints all available products.
	/// </summary>
	public static void PrintAvailableProducts()
	{
		GD.Print("\n=== Available Products ===\n");
		foreach (var product in AvailableProducts)
		{
			GD.Print($"Product: {product.Name}");
			GD.Print($"- Made By: {product.MadeBy}");
			GD.Print($"- Cost to Build: {product.CostToBuild}");
			GD.Print($"- Time to Build: {product.TimeToBuild}");
			GD.Print($"- Current Quantities: {product.CurrentQuantities}");
			GD.Print($"- Material From: {Utils.FormatMaterialDictionary(product.MaterialFrom)}");
			GD.Print($"- Sell To: {Utils.FormatSellDictionary(product.SellTo)}");
			GD.Print("---\n");
		}
		GD.Print("=== End of Available Products ===\n");
	}
}
