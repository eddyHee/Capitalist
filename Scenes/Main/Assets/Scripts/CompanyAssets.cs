using Godot;
using System;

public partial class CompanyAssets : CanvasLayer
{
	
	private AnimationPlayer _animPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button closeAssetButton = GetNode<Button>("%CloseAsset");
		
		if(closeAssetButton != null){
			closeAssetButton.Pressed += OncloseAssetButtonPressed;
		} else {
			GD.PrintErr("closeAssetButton not found!");
		}
		
		// Get the animation player
		_animPlayer = GetNode<AnimationPlayer>($"Anim");
		if(_animPlayer == null)
		{
			GD.PrintErr("AnimationPlayer not found!");
		}
	}

	public void OncloseAssetButtonPressed(){
		GD.Print("Close Asset button pressed...");
		
		_animPlayer?.Play("TransOut");
		
	}
}
