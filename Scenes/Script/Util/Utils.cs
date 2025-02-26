using System;
using System.Collections.Generic;
using System.Linq;

public static class Utils
{
	/// <summary>
	/// Formats the contents of a dictionary into a readable string.
	/// </summary>
	public static string FormatDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
	{
		if (dictionary == null || dictionary.Count == 0)
		{
			return "None";
		}

		var entries = dictionary.Select(entry => $"{entry.Key}: {entry.Value}").ToList();
		return string.Join(", ", entries);
	}

	/// <summary>
	/// Formats a dictionary with (int Quantity, float PricePerUnit) values into a readable string.
	/// </summary>
	public static string FormatMaterialDictionary(Dictionary<Product, (int Quantity, float PricePerUnit)> dictionary)
	{
		if (dictionary == null || dictionary.Count == 0)
		{
			return "None";
		}

		var entries = dictionary.Select(entry => $"{entry.Key.Name} (Qty: {entry.Value.Quantity}, Price: {entry.Value.PricePerUnit})").ToList();
		return string.Join(", ", entries);
	}
	
		/// <summary>
	/// Formats a dictionary with (int Quantity, float PricePerUnit) values into a readable string.
	/// </summary>
	public static string FormatSellDictionary(Dictionary<String, (int Quantity, float PricePerUnit)> dictionary)
	{
		if (dictionary == null || dictionary.Count == 0)
		{
			return "None";
		}

		var entries = dictionary.Select(entry => $"{entry.Key} (Qty: {entry.Value.Quantity}, Price: {entry.Value.PricePerUnit})").ToList();
		return string.Join(", ", entries);
	}
}
