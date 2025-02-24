using Godot;
using System;

public partial class LandingBg : ParallaxBackground
{
	[Export] private float ScrollSpeed = 50f; // Adjust speed in inspector
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Scroll horizontally (left-to-right)
		ScrollOffset = new Vector2(
			ScrollOffset.X - (ScrollSpeed * (float)delta),
			ScrollOffset.Y
		);
	}
}
