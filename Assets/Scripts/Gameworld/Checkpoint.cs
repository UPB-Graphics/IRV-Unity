using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLocation
{
	NotSet,

	Location1,
	Location2,
	Location3,
	
	// 
	Count
}

public class Checkpoint : MonoBehaviour
{
	public GameLocation location;

	// Use this for initialization
	void Start ()
	{
		//var value = Enum.GetValues(typeof(GameLocation));
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (GameData.Instance.locationID != location)
		{
			Debug.Log("TriggerArea");
			GameData.Instance.locationID = location;
			GameData.Save();
			AudioManager.PlayAmbientalSound(AudioResources.Instance.ambientalMusic[(int)AmbientalMusic.SaveSound]);
		}
	}
}
