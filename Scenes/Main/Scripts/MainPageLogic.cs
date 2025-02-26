using Godot;

public partial class MainPageLogic : ParallaxBackground
{
	// Node references
	// Node from main_controls
	private Button _assetButton;
	private Button _manageProductButton;
	
	// Node from company_assets
	private Control _companyInfo;
	private Control _productManagement;
	private AnimationPlayer _animPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitializeNodes();
		ConnectSignals();
	}
	
	// Initialize all node references
	private void InitializeNodes()
	{
		_assetButton = GetNodeOrNull<Button>("%AssetButton");
		_manageProductButton = GetNodeOrNull<Button>("%ManageProductButton");
		_animPlayer = GetNodeOrNull<AnimationPlayer>($"../company_assets/Anim");
		_companyInfo = GetNodeOrNull<Control>($"../company_assets/CompanyInfo");
		_productManagement = GetNodeOrNull<Control>($"../company_assets/ProductManagement");

		// Log errors if nodes are not found
		if (_assetButton == null) GD.PrintErr("AssetButton not found!");
		if (_manageProductButton == null) GD.PrintErr("ManageProductButton not found!");
		if (_animPlayer == null) GD.PrintErr("AnimationPlayer not found!");
		if (_companyInfo == null) GD.PrintErr("CompanyInfo control not found!");
		if (_productManagement == null) GD.PrintErr("ProductManagement control not found!");
	}
	
	
	// Connect button signals to methods
	private void ConnectSignals()
	{
		if (_assetButton != null)
		{
			_assetButton.Pressed += OnAssetButtonPressed;
		}

		if (_manageProductButton != null)
		{
			_manageProductButton.Pressed += OnManageProductButtonPressed;
		}
	}
	
	// Handle AssetButton press
	private void OnAssetButtonPressed()
	{
		GD.Print("Asset button pressed...");
		ShowPanel(_companyInfo, _productManagement);
	}
	
	// Handle ManageProductButton press
	private void OnManageProductButtonPressed()
	{
		GD.Print("Market button pressed...");
		ShowPanel(_productManagement, _companyInfo);
	}
	
	// Show one panel and hide the other
	private void ShowPanel(Control panelToShow, Control panelToHide)
	{
		if (panelToShow != null) panelToShow.Visible = true;
		if (panelToHide != null) panelToHide.Visible = false;

		_animPlayer?.Play("TransIn");

		// Hide and disable buttons
		if (_assetButton != null)
		{
			_assetButton.Visible = false;
			_assetButton.Disabled = true;
		}

		if (_manageProductButton != null)
		{
			_manageProductButton.Visible = false;
			_manageProductButton.Disabled = true;
		}
	}
	
}
