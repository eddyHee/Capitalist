using Godot;

public partial class MaterialCostSlot : Panel
{
	[Export] private Label _materialNameLabel;
	[Export] private Label _materialCost;
	[Export] private Label _madeBy;
	[Export] private TextureButton _clickableButton; // Reference to the button
	
	// Optional: Define a delegate for the click event
	public delegate void SlotClickedEventHandler(string materialName);
	public event SlotClickedEventHandler OnSlotClicked;
	
	// Called when the node enters the scene tree
	public override void _Ready()
	{
		// Connect the button's pressed signal to a method
		if (_clickableButton != null)
		{
			_clickableButton.Pressed += OnButtonPressed;
			// Add hover effects to the TextureButton
			UIUtil.AddHoverEffects(_clickableButton);
		}
		else
		{
			GD.PrintErr("Clickable button is not assigned in MaterialCostSlot!");
		}
	}

	public void SetMaterialCostData(string materialName, string materialCost, string madeBy)
	{
		_materialNameLabel.Text = materialName;
		_materialCost.Text = $"${materialCost}";
		_madeBy.Text = $"made by {madeBy}";
	}
	
	// Method to handle button click
	private void OnButtonPressed()
	{
		GD.Print($"MaterialCostSlot clicked: {_materialNameLabel.Text}");
		
		// Trigger the event if subscribed
		OnSlotClicked?.Invoke(_materialNameLabel.Text);
	}
}
