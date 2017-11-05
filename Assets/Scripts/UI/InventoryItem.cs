using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class InventoryItem
{
	public InventoryItem()
	{ }

	public InventoryItem(int ID, int icontID, int level, string name, string description)
	{
		this.ID = ID;
		this.iconID = icontID;
		this.level = level;
		this.name = name;
		this.description = description;
	}

	[XmlElement("ID")]
	public int ID { get; private set; }

	[XmlElement("iconID")]
	public int iconID { get; private set; }

	[XmlElement("level")]
	public int level { get; private set; }

	[XmlElement("name")]
	public string name { get; private set; }

	[XmlElement("description")]
	public string description { get; private set; }
}

