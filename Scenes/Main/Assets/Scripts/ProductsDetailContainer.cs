using Godot;
using System;

public partial class ProductsDetailContainer : GridContainer
{
	[Export] private GridContainer _productsDetailContainer;
	[Export] private PackedScene _productDetailSlotScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_productsDetailContainer == null || _productDetailSlotScene == null)
		{
			GD.PrintErr("ProductContainer or ProductSlotScene is not assigned!");
			return;
		}

		PopulateProducts();
	}

	private void PopulateProducts()
	{
		foreach (Node child in _productsDetailContainer.GetChildren())
		{
			child.QueueFree();
		}

		var products = AssetData.Products;

		foreach (var product in products)
		{
			var slot = _productDetailSlotScene.Instantiate<ProductDetailSlot>();
			slot.SetProductData(	product);
			_productsDetailContainer.AddChild(slot);
		}
	}
}
