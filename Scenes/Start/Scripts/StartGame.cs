using Godot;
using System;

public partial class StartGame : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{		
		Button startButton = GetNode<Button>("%StartGameButton");
		
		if(startButton != null){
			startButton.Pressed += OnStartButtonPressed;
		} else {
			GD.PrintErr("StartGameButton not found!");
		}
	}
	
	public void OnStartButtonPressed(){
		GD.Print("Starting transition...");
		
		
		GetTree().ChangeSceneToFile("res://scenes/main/mainPage.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
