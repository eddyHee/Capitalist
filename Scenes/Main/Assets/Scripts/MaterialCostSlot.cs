using Godot;

public partial class MaterialCostSlot : Panel
{
	[Export] private Label _materialNameLabel;
	[Export] private Label _materialCost;

	public void SetMaterialCostData(string materialName, string materialCost)
	{
		_materialNameLabel.Text = materialName;
		_materialCost.Text = $"${materialCost}";
	}
}
