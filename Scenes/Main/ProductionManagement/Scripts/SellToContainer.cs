using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SellToContainer : GridContainer
{
	[Export] private GridContainer _sellToCostContainer;
	[Export] private PackedScene _sellToSlotScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_sellToCostContainer == null || _sellToSlotScene == null)
		{
			GD.PrintErr("SellToContainer or _sellToSlotScene is not assigned!");
			return;
		}

	}
	
	
	public void PopulateMaterials(Dictionary<String, (int Quantity, float PricePerUnit)> SellTo)
	{
		GD.Print("Testing: called Sell to here!!!!!!!!");
		foreach (Node child in _sellToCostContainer.GetChildren())
		{
			child.QueueFree();
		}

		//var products = AssetData.Products;

		foreach (var sell in SellTo)
		{
			// Access the key (Product) and value (Quantity, PricePerUnit)
			var buyer = sell.Key; // Key is the seller
			var quantity = sell.Value.Quantity; // Value is a tuple (int Quantity, float PricePerUnit)
			var pricePerUnit = sell.Value.PricePerUnit;

			// Instantiate a new slot and set its data
			var slot = _sellToSlotScene.Instantiate<SellToSlot>();
			slot.SetSellToData(buyer, $"{pricePerUnit}");
			_sellToCostContainer.AddChild(slot);
		}
	}
}
