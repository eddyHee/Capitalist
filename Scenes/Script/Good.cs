using Godot;
using System.Collections.Generic;

/* Summary
Goods class just holding basic information about each good
*/
public class Good
{
	public string Name { get; set; }
	public List<Good> GoodsRequired { get; set; }
	public int BasicTimeToBuild { get; set; }
	
	public Good(string name, int basicTimeToBuild, List<Good> goodsRequired)
	{
		Name = name;
		BasicTimeToBuild = basicTimeToBuild;
		GoodsRequired = goodsRequired;
	}
}
