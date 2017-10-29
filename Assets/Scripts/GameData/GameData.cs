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
	public int locationID;

	[XmlElement("Item")]
	public ChestBox item = new ChestBox("ChestBox 3", "ASd", GameLocation.Location2);

	[XmlArray("Rewards")]
	public List<ChestBox> rewards = new List<ChestBox>();

	public static void Save()
	{
		// Save game state into XML
		var serializer = new XmlSerializer(typeof(GameData));
		var stream = new FileStream(gameDataFile, FileMode.Create);
		serializer.Serialize(stream, Instance);
		stream.Close();

		Debug.Log("Gameplay saved: " + gameDataFile);
	}

	public static void Load()
	{
		if (File.Exists(gameDataFile))
		{
			// Load info from XML
			var serializer = new XmlSerializer(typeof(GameData));
			var stream = new FileStream(gameDataFile, FileMode.Open);
			Instance = serializer.Deserialize(stream) as GameData;
			stream.Close();

			Debug.Log("Gameplay loaded: " + gameDataFile);

			isLoaded = true;
			if (OnLoad != null)
				OnLoad();
		}
		else
		{
			NewGame();
			Save();
		}
	}

	public static void NewGame()
	{
		var c1 = new ChestBox("ChestBox 1", "Something 1", GameLocation.Location1);
		var c2 = new ChestBox("ChestBox 2", "Something 2", GameLocation.Location2);
		Instance.rewards.Add(c1);
		Instance.rewards.Add(c2);
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
}
