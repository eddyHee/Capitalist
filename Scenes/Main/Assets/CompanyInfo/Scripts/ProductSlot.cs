using Godot;

public partial class ProductSlot : Panel
{
	[Export] private Label _productNameLabel;

	public void SetProductData(string productName)
	{
		_productNameLabel.Text = productName;
	}
}
