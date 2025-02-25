using Godot;
using System.Collections.Generic;

/* Summary
Product class should contain information about a goods that a company made

if product is not made by player company, then some data is not visiable
*/
public class Product
{
	public Good Good { get; set; }    
	public string MadeBy { get; set; }
	
	
	private float CostToBuild;
	private float TimeToBuild;
	private int CurrentQuantities;
	private Dictionary<string, (int Quantity, float PricePerUnit)> MaterialFrom;
	private bool CanMake;
	private Dictionary<string, (int Quantity, float PricePerUnit)> SellTo;
	
	// Note: this property is used for bypass some validation
	private bool _isMadeByPlayer;
	//read-only property
	public bool IsMadeByPlayer => _isMadeByPlayer;
	
	// Create Product runtime. Design for player add new Product
	// some properties will be added later
	public Product(Good good, string madeBy, bool isMadeByPlayer)
	{
		Good = good;
		MadeBy = madeBy;
		_isMadeByPlayer = isMadeByPlayer;
	}
	
	// Preload Product.
	// Design for madeby NPC company
	public Product(Good good, string madeBy, float costToBuild, float timeToBuild, int currentQuantities)
	{
		Good = good;
		MadeBy = madeBy;
		CostToBuild = costToBuild;
		TimeToBuild = timeToBuild;
		CurrentQuantities = currentQuantities;
		_isMadeByPlayer = false;
	}
	
	
}
