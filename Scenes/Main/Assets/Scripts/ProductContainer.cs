using Godot;
using System;

public partial class ProductContainer : GridContainer
{
	[Export] private GridContainer _productContainer;
	[Export] private PackedScene _productSlotScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_productContainer == null || _productSlotScene == null)
		{
			GD.PrintErr("ProductContainer or ProductSlotScene is not assigned!");
			return;
		}

		PopulateProducts();
		
	}

	private void PopulateProducts()
	{
		foreach (Node child in _productContainer.GetChildren())
		{
			child.QueueFree();
		}

		var products = AssetData.Products;

		foreach (var product in products)
		{
			var slot = _productSlotScene.Instantiate<ProductSlot>();
			slot.SetProductData(product.Name);
			_productContainer.AddChild(slot);
		}
	}
}
