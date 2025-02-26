using Godot;

/* Summary
This class is attached to company_assets(CanvasLayer)

The company_assets is a info panel designed to show all infomation about the company
*/
public partial class CompanyAssets : CanvasLayer
{
	
	// Node references
	// Nodes in company_assets
	private AnimationPlayer _animPlayer;
	private Button _closeAssetButton;
	private Button _manageProductButton;
	private Label _moneyValue;
	private Label _companyNameValue;
	
	// Nodes in main_controls
	private Button _assetButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitializeNodes();
		InitializeNodesValue();
		ConnectSignals();
	}
	
	// Initialize all node references
	private void InitializeNodes()
	{
		_closeAssetButton = GetNode<Button>("%CloseAsset");
		_animPlayer = GetNode<AnimationPlayer>($"Anim");
		_moneyValue = GetNode<Label>("%MoneyValue");
		_companyNameValue = GetNode<Label>("%CompanyNameValue");
		_assetButton = GetNode<Button>($"../main_controls/AssetButton");
		_manageProductButton = GetNode<Button>($"../main_controls/ManageProductButton");

		// Log errors if nodes are not found
		if(_closeAssetButton == null) GD.PrintErr("closeAssetButton not found!");
		if(_animPlayer == null) GD.PrintErr("AnimationPlayer not found!");
		if(_moneyValue == null) GD.PrintErr("Money value label not found!");
		if(_companyNameValue == null) GD.PrintErr("Company name value label not found!");
		if(_assetButton == null) GD.PrintErr("assetButton not found!");
		if(_manageProductButton == null) GD.PrintErr("Manage Produce button not found!");
	}
	
	private void InitializeNodesValue()
	{
		if (_moneyValue != null)
		{
			_moneyValue.Text = AssetData.Instance.Money.ToString();
		}
		if (_companyNameValue != null)
		{
			_companyNameValue.Text = AssetData.Instance.CompanyName;
			
		}
	}
	
	// Connect button signals to methods
	private void ConnectSignals()
	{
		if (_closeAssetButton != null)
		{
			_closeAssetButton.Pressed += OncloseAssetButtonPressed;
		}
	}
	
	/* Summary
	This method close the panel
	
	note: 
	the asset button(in the main_controls) are disabled and invisiable when this panel is showing
	undo these changes when remove the panel
	*/
	public void OncloseAssetButtonPressed(){
		GD.Print("Close Asset button pressed...");
		
		_animPlayer?.Play("TransOut");
		
		// Show and enable the button
		if(_assetButton != null)	{
			_assetButton.Visible = true; // Make visible
			_assetButton.Disabled = false;  // allow interaction
			_manageProductButton.Visible = true;
			_manageProductButton.Disabled = false;
		}
	}
	
}
