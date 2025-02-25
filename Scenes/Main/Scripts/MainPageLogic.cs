using Godot;
using System;

public partial class MainPageLogic : ParallaxBackground
{
	private AnimationPlayer _animPlayer;
	private Button _assetButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_assetButton = GetNode<Button>("%AssetButton");
		
		if(_assetButton != null){
			_assetButton.Pressed += OnAssetButtonPressed;
		} else {
			GD.PrintErr("assetButton not found!");
		}
		
		// Get the animation player
		_animPlayer = GetNode<AnimationPlayer>($"../company_assets/Anim");
		if(_animPlayer == null)
		{
			GD.PrintErr("AnimationPlayer not found!");
		}
	}
	
	public void OnAssetButtonPressed(){
		GD.Print("Asset button pressed...");
		
		_animPlayer?.Play("TransIn");
		// Hide and disable the button
		if(_assetButton != null)	{
			_assetButton.Visible = false; // Make invisible
			_assetButton.Disabled = true;  // Prevent interaction
		}
		
	}
}
