using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

using UnityEngine;


//[System.Serializable]
public class ChestBox
{
	[XmlAttribute("Name")]
	public string name;
	[XmlElement("Description")]
	public string description;
	[XmlElement("Location")]
	public GameLocation location;
	[XmlElement("Found")]
	public bool isFound;

	public ChestBox()
	{ }

	public ChestBox(string name, string description, GameLocation location)
	{
		this.name = name;
		this.description = description;
		this.location = location;
		isFound = false;
	}
}
