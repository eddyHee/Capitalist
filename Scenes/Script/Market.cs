using Godot;
using System.Collections.Generic;

public class Market
{
	public List<Good> AvailableGoods { get; set; }

	public Market()
	{
		// Initialize default goods
		AvailableGoods = CreateDefaultGoods();
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
