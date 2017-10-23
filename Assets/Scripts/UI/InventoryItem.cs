using System.Collections;
using System.Collections.Generic;

public class InventoryItem
{
	public InventoryItem(int icontID, int level, string name, string description)
	{
		this.iconID = icontID;
		this.level = level;
		this.name = name;
		this.description = description;
	}

	public int iconID { get; private set; }
	public int level { get; private set; }
	public string name { get; private set; }
	public string description { get; private set; }
}

