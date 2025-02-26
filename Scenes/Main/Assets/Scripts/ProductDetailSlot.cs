using Godot;
using System;

public partial class ProductDetailSlot : Panel
{
	[Export] private Label _productName;
	[Export] private Label _progressStatus;
	[Export] private Label _storage;
	[Export] private Label _netProfit;    
	[Export] private MaterialCostContainer _materialCostContainer; // Reference to the MaterialCostContainer node

	public void SetProductData(Product product)
	{
		_productName.Text = product.Name;
		
		// Pass the product to MaterialCostContainer to populate material data
		if (_materialCostContainer != null)
		{
			_materialCostContainer.PopulateMaterials(product.MaterialFrom);
		}
		else
		{
			GD.PrintErr("MaterialCostContainer is not assigned in ProductDetailSlot!");
		}
	}
}
