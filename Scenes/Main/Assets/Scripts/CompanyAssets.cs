using Godot;
using System;

public partial class CompanyAssets : CanvasLayer
{
	
	private AnimationPlayer _animPlayer;
	private Button _assetButton;
	private Button _closeAssetButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get close asset button
		GetCloseAsset();
		// Get the asset button
		GetAssetButton();
		// Get the animation player
		GetAnimationPlayer();
	}

	public void OncloseAssetButtonPressed(){
		GD.Print("Close Asset button pressed...");
		
		_animPlayer?.Play("TransOut");
		
		// Show and enable the button
		if(_assetButton != null)	{
			_assetButton.Visible = true; // Make visible
			_assetButton.Disabled = false;  // allow interaction
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
	
	private void GetAssetButton(){
		_assetButton = GetNode<Button>($"../main_controls/AssetButton");
		
		if(_assetButton != null){
			//_assetButton.Pressed += OnAssetButtonPressed;
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
