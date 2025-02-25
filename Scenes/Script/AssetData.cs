using Godot;

[GlobalClass]
public partial class AssetData : Node
{
	// Singleton instance
	private static AssetData _instance;
	public static AssetData Instance => _instance;

	// Example global data
	public int Money { get; set; } = 1000;
	public string CompanyName { get; set; } = "CAP";

	// Called when the node enters the scene tree
	public override void _EnterTree()
	{
		// Ensure only one instance exists
		if (_instance != null)
		{
			QueueFree(); // Destroy duplicate instances
			return;
		}
		_instance = this;
	}
}
