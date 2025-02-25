using Godot;
using System;

public partial class MainPageLogic : ParallaxBackground
{
	private AnimationPlayer _animPlayer;
	private Button _assetButton;
	private Button _marketButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get asset button
		GetAssetButton();
		// Get market button
		GetMarketButton();
		// Get the animation player
		GetAnimationPlayer();
		
	}
	
	public void OnAssetButtonPressed(){
		GD.Print("Asset button pressed...");
		
		_animPlayer?.Play("TransIn");
		// Hide and disable the button
		if(_assetButton != null)	{
			_assetButton.Visible = false; // Make invisible
			_assetButton.Disabled = true;  // Prevent interaction
			_marketButton.Visible = false;
			_marketButton.Disabled = true;
		}
	}
	
	public void OnMarketButtonPressed()
	{
		GD.Print("Market button pressed...");
	}
	
	private void GetAssetButton(){
		_assetButton = GetNode<Button>("%AssetButton");
		
		if(_assetButton != null){
			_assetButton.Pressed += OnAssetButtonPressed;
		} else {
			GD.PrintErr("assetButton not found!");
		}
	}
	
	private void GetMarketButton(){
		_marketButton = GetNode<Button>("%MarketButton");
		
		if(_marketButton != null)
		{
			_marketButton.Pressed += OnMarketButtonPressed;
		}
		else
		{
			GD.PrintErr("market button not found!");
		}
	}
	
	private void GetAnimationPlayer(){
		_animPlayer = GetNode<AnimationPlayer>($"../company_assets/Anim");
		if(_animPlayer == null)
		{
			GD.PrintErr("AnimationPlayer not found!");
		}
	}
}
