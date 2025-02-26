using Godot;

public static class UIUtil
{
	/// <summary>
	/// Adds hover effects to a TextureButton (pop-up effect with scaling and movement).
	/// </summary>
	/// <param name="button">The TextureButton to add hover effects to.</param>
	public static void AddHoverEffects(TextureButton button)
	{
		// Store the original scale, position, and modulate color
		var originalScale = button.Scale;
		var originalPosition = button.Position;
		var originalModulate = button.Modulate;

		// Connect signals for hover effects
		button.MouseEntered += () => OnMouseEntered(button, originalScale, originalPosition, originalModulate);
		button.MouseExited += () => OnMouseExited(button, originalScale, originalPosition, originalModulate);
	}

	private static void OnMouseEntered(TextureButton button, Vector2 originalScale, Vector2 originalPosition, Color originalModulate)
	{
		GD.Print("Mouse entered button");

		// Apply hover effects
		button.Scale = originalScale * 1.1f; // Scale up slightly
		button.Position = originalPosition - new Vector2(0, 5); // Move upward slightly
		button.Modulate = new Color(1.2f, 1.2f, 1.2f); // Brighten the color

		// Add a shadow or border effect (optional)
		var styleBox = new StyleBoxFlat();
		styleBox.ShadowColor = new Color(0, 0, 0, 0.5f); // Semi-transparent black shadow
		styleBox.ShadowSize = 4; // Shadow size
		button.AddThemeStyleboxOverride("normal", styleBox);
	}

	private static void OnMouseExited(TextureButton button, Vector2 originalScale, Vector2 originalPosition, Color originalModulate)
	{
		GD.Print("Mouse exited button");

		// Reset to original state
		button.Scale = originalScale;
		button.Position = originalPosition;
		button.Modulate = originalModulate;

		// Remove the shadow or border effect
		button.RemoveThemeStyleboxOverride("normal");
	}
}
