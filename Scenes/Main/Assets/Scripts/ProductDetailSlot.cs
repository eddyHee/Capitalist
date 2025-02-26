using Godot;
using System;

public partial class ProductDetailSlot : Panel
{
	[Export] private Label _productName;
	[Export] private Label _progressStatus;
	[Export] private Label _storage;
	[Export] private Label _netProfit;    
	[Export] private MaterialCostContainer _materialCostContainer; // Reference to the MaterialCostContainer node
	[Export] private SellToContainer _sellToContainerContainer; // Reference to the SellToContainer node


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
		
		// Pass the product to SellToContainer to populate material data
		if (_sellToContainerContainer != null)
		{
			_sellToContainerContainer.PopulateMaterials(product.SellTo);
		}
		else
		{
			GD.PrintErr("SellToContainerContainer is not assigned in ProductDetailSlot!");
		}
	}
}
