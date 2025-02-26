using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/* Summary
This class is attached to MaterialCostContainer(GridContainer)

it shows Material cost of each product dynamically 
*/

public partial class MaterialCostContainer : GridContainer
{
	[Export] private GridContainer _materialCostContainer;
	[Export] private PackedScene _materialCostSlotScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_materialCostContainer == null || _materialCostSlotScene == null)
		{
			GD.PrintErr("MaterialCostContainer or materialCostSlotScene is not assigned!");
			return;
		}

		//PopulateMaterials();
	}

	public void PopulateMaterials(Dictionary<Product, (int Quantity, float PricePerUnit)> MaterialFrom)
	{
		GD.Print("Testing: called here!!!!!!!!");
		foreach (Node child in _materialCostContainer.GetChildren())
		{
			child.QueueFree();
		}

		//var products = AssetData.Products;

		foreach (var materialEntry in MaterialFrom)
		{
			// Access the key (Product) and value (Quantity, PricePerUnit)
			var product = materialEntry.Key; // Key is the Product
			var quantity = materialEntry.Value.Quantity; // Value is a tuple (int Quantity, float PricePerUnit)
			var pricePerUnit = materialEntry.Value.PricePerUnit;

			// Instantiate a new slot and set its data
			var slot = _materialCostSlotScene.Instantiate<MaterialCostSlot>();
			slot.SetMaterialCostData(product.Name, $"{pricePerUnit}", product.MadeBy);
			_materialCostContainer.AddChild(slot);
		}
	}
	
	// Method to handle slot clicks
	private void HandleSlotClicked(string materialName)
	{
		GD.Print($"MaterialCostContainer: Slot clicked for material {materialName}");
		
		// Add your custom logic here
		// For example, open a detailed view or update UI
	}
}
