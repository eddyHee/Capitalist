using Godot;
using System;

public partial class SellToSlot : Panel
{
	[Export] private Label _price;
	[Export] private Label _buyer;

	public void SetSellToData(string buyer, string price)
	{
		_buyer.Text = buyer;
		_price.Text = $"${price}";
	}
}
