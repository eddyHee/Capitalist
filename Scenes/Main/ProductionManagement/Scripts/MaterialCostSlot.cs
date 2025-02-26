using Godot;

public partial class MaterialCostSlot : Panel
{
	[Export] private Label _materialNameLabel;
	[Export] private Label _materialCost;
	[Export] private Label _madeBy;

	public void SetMaterialCostData(string materialName, string materialCost, string madeBy)
	{
		_materialNameLabel.Text = materialName;
		_materialCost.Text = $"${materialCost}";
		_madeBy.Text = $"made by {madeBy}";
	}
}
