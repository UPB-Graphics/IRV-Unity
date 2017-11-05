using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

// For XML serialization
using System.Xml.Serialization;

[XmlRoot("GameData")]
public class GameData
{
	public static GameData Instance = new GameData();
	private static string XMLFileName = "/GameData.xml";
	private static string gameDataFile = Application.persistentDataPath + XMLFileName;

	private static bool isLoaded;
	public delegate void LoadEvent();
	public static event LoadEvent OnLoad;

	[XmlElement("GameLocation")]
	public GameLocation locationID;

	[XmlElement("Item")]
	public ChestBox item = new ChestBox("ChestBox 3", "ASd", GameLocation.Location2);

	[XmlArray("Rewards")]
	public List<ChestBox> rewards = new List<ChestBox>();

	[XmlArray("Items")]
	public List<InventoryItem> items = new List<InventoryItem>();

	[XmlArray("Pickups")]
	public List<InventoryItem> pickups = new List<InventoryItem>();

	public static void Save()
	{
		// Save game state into XML
		var serializer = new XmlSerializer(typeof(GameData));
		var stream = new FileStream(gameDataFile, FileMode.Create);
		serializer.Serialize(stream, Instance);
		stream.Close();

		Debug.Log("Gameplay saved again: " + gameDataFile);
	}

	public static void Load()
	{
		Debug.Log(gameDataFile);

		if (File.Exists(gameDataFile))
		{
			// Load info from XML
			var serializer = new XmlSerializer(typeof(GameData));
			var stream = new FileStream(gameDataFile, FileMode.Open);
			try
			{
				Instance = serializer.Deserialize(stream) as GameData;
				stream.Close();

				Debug.Log("Gameplay loaded: " + gameDataFile);
				Debug.Log(Instance.pickups.Count);

				isLoaded = true;
				if (OnLoad != null)
					OnLoad();
			}
			catch (SystemException e)
			{
				stream.Close();
				NewGame();
				Save();
			}
		}
		else
		{
			NewGame();
			Save();
		}
	}

	public static void NewGame()
	{
		Instance.items.Clear();
		Instance.pickups.Clear();

		// list of InventorItems
		Instance.items.Add(new InventoryItem(0, 1, 10, "Sword of...", "Legendary something"));
		Instance.items.Add(new InventoryItem(1, 2, 5, "Armor", "ASidgoiasd"));
		Instance.items.Add(new InventoryItem(2, 1, 10, "Boots", "Info"));
		Instance.items.Add(new InventoryItem(3, 1, 10, "Whatever", "adsfhasdfsdf"));

		Instance.pickups.Add(new InventoryItem(4, 1, 12, "Item 4", "Description for item 4"));
		Instance.pickups.Add(new InventoryItem(5, 1, 7, "Item 5", "Description for item 5"));
		Instance.pickups.Add(new InventoryItem(7, 1, 7, "Item 6", "Description for item 6"));

		var c1 = new ChestBox("ChestBox 1", "Something 1", GameLocation.Location1);
		var c2 = new ChestBox("ChestBox 2", "Something 2", GameLocation.Location2);
		Instance.rewards.Add(c1);
		Instance.rewards.Add(c2);
	}

	public static void PickItem(InventoryItem item)
	{
		Instance.pickups.Remove(item);
		Instance.items.Add(item);
	}

	public static void OnDataInit(LoadEvent callback)
	{
		OnLoad += callback;

		if (isLoaded == true)
		{
			callback();
		}
		else
		{
			Debug.Log("Game Data Not loaded!");
		}
	}

	public static void RemoveCallback(LoadEvent callback)
	{
		OnLoad -= callback;
	}
}
