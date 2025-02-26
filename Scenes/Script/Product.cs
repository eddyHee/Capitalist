using Godot;
using System.Collections.Generic;

/// <summary>
/// Represents a product made by a company.
/// If the product is not made by the player's company, some data is not visible.
/// </summary>
public class Product
{
	// Read-only properties
	public string Name => Good.Name; // Name of the product (derived from the Good)
	
	// Properties
	public Good Good { get; private set; } // The good this product represents
	public string MadeBy { get; private set; } // The company that made this product
	public bool IsMadeByPlayer { get; private set; } // Whether the product is made by the player's company
	public float CostToBuild { get; private set; } // Cost to build the product
	public float TimeToBuild { get; private set; } // Time to build the product
	public int CurrentQuantities { get; private set; } // Current stock of the product

	// Material and sales data
	public Dictionary<Product, (int Quantity, float PricePerUnit)> MaterialFrom { get; private set; }
	public Dictionary<string, (int Quantity, float PricePerUnit)> SellTo { get; private set; }

	// Whether the product can be made
	public bool CanMake { get; private set; }

	/// <summary>
	/// Constructor for creating a product at runtime (e.g., for player-created products).
	/// Some properties will be added later.
	/// </summary>
	public Product(Good good, string madeBy, bool isMadeByPlayer)
	{
		Good = good;
		MadeBy = madeBy;
		IsMadeByPlayer = isMadeByPlayer;

		// Initialize collections
		MaterialFrom = new Dictionary<Product, (int Quantity, float PricePerUnit)>();
		SellTo = new Dictionary<string, (int Quantity, float PricePerUnit)>();
	}

	/// <summary>
	/// Constructor for preloading a product (e.g., for NPC-made products).
	/// </summary>
	public Product(Good good, string madeBy, float costToBuild, float timeToBuild, int currentQuantities)
		: this(good, madeBy, false) // Call the primary constructor
	{
		CostToBuild = costToBuild;
		TimeToBuild = timeToBuild;
		CurrentQuantities = currentQuantities;
	}

	/// <summary>
	/// Adds material requirements for the product.
	/// </summary>
	public void AddMaterialRequirement(Product material, int quantity, float pricePerUnit, bool updateSales)
	{
		GD.Print("\n=== Adding Material Requirement ===\n");

		// Print details about the material being added
		GD.Print($">> Adding Material: {material.Name}");
		GD.Print($">> Quantity Required: {quantity}");
		GD.Print($">> Price Per Unit: {pricePerUnit}");

		// Add the material requirement to the product
		MaterialFrom[material] = (quantity, pricePerUnit);
		GD.Print($">> Material '{material.Name}' added to '{Name}' successfully.\n");

		// Update the sales record for the material
		if(updateSales)
		{
			GD.Print($">> Updating Sales Record for Material: {material.Name}");
			material.AddSalesRecord(MadeBy, quantity, pricePerUnit);
			GD.Print($">> Sales record updated for '{material.Name}'.\n");

			GD.Print("=== Material Requirement Added Successfully ===\n");
		}
	}

	/// <summary>
	/// Adds a sales record for the product.
	/// </summary>
	public void AddSalesRecord(string buyer, int quantity, float pricePerUnit)
	{
		GD.Print("\n=== Adding Sales Record ===\n");

		// Print details about the sales record being added
		GD.Print($">> Buyer: {buyer}");
		GD.Print($">> Product: {Name}");
		GD.Print($">> Quantity Sold: {quantity}");
		GD.Print($">> Price Per Unit: {pricePerUnit}");

		// Add the sales record to the product
		SellTo[buyer] = (quantity, pricePerUnit);
		GD.Print($">> Sales record added for '{Name}' to buyer '{buyer}' successfully.\n");

		GD.Print("=== Sales Record Added Successfully ===\n");
	}

	/// <summary>
	/// Updates the product's ability to be made.
	/// </summary>
	public void UpdateCanMake(bool canMake)
	{
		CanMake = canMake;
	}
}
