using Godot;
using System;

/* Summary
This class is attached to company_assets(CanvasLayer)

The company_assets is a info panel designed to show all infomation about the company
*/
public partial class CompanyAssets : CanvasLayer
{
	
	// Nodes in company_assets
	private AnimationPlayer _animPlayer;
	private Button _closeAssetButton;
	private Label _moneyValue;
	private Label _companyNameValue;
	
	// Nodes in main_controls
	private Button _assetButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Nodes in company_assets
		GetCloseAsset();
		GetAnimationPlayer();
		GetMoneyValue();
		GetCompanyNameValue();
		
		// Nodes in main_controls
		GetAssetButton();
		
		
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
		}
	}
	
	/* Summary
	The methods below are getting nodes
	
	setup action
	init value
	*/
	private void GetMoneyValue() {
		_moneyValue = GetNode<Label>("%MoneyValue");
		
		if(_moneyValue != null) {
			_moneyValue.Text = AssetData.Instance.Money.ToString();
		} else {
			GD.PrintErr("Money text Edit not found!");
		}
	}
	
	private void GetCompanyNameValue() {
		_companyNameValue = GetNode<Label>("%CompanyNameValue");
		
		if(_companyNameValue != null) {
			_companyNameValue.Text = AssetData.Instance.CompanyName;
		} else {
			GD.PrintErr("Money text Edit not found!");
		}
	}
	
	private void GetCloseAsset(){
		_closeAssetButton = GetNode<Button>("%CloseAsset");
		
		if(_closeAssetButton != null){
			_closeAssetButton.Pressed += OncloseAssetButtonPressed;
		} else {
			GD.PrintErr("closeAssetButton not found!");
		}
	}
	
	// NOTE:
	// asset button should be disabled and invisiable when showing this info panel
	// we need to revert the changes when close panel
	// no connection needed in the button click
	private void GetAssetButton(){
		_assetButton = GetNode<Button>($"../main_controls/AssetButton");
		
		if(_assetButton != null){
			
		} else {
			GD.PrintErr("assetButton not found!");
		}
	}
	
	private void GetAnimationPlayer(){
		_animPlayer = GetNode<AnimationPlayer>($"Anim");
		if(_animPlayer == null)
		{
			GD.PrintErr("AnimationPlayer not found!");
		}
	}
	
	
}
