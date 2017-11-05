using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
	public int itemID;
	public InventoryItem item;
	public InventoryEntry uiEntry;
	public AudioSource pickupSound;
	private bool canPick = false;

	// Use this for initialization
	void Start ()
	{
		GameData.OnDataInit(Init);
	}

	private void Init()
	{
		bool found = false;
		foreach (var item in GameData.Instance.pickups)
		{
			if (item.ID == itemID)
			{
				found = true;
				SetItem(item);
			}
		}
		if (!found)
		{
			Debug.LogWarning("Pickup Item has an invalid itemID");
			Destroy(gameObject);
			GameData.RemoveCallback(Init);
		}
	}

	void SetItem(InventoryItem item)
	{
		// TODO
		this.item = item;
		uiEntry.SetItem(item);
	}

	// Update is called once per frame
	void Update () {
		if (canPick && Input.GetKeyDown(KeyCode.E))
		{
			canPick = false;
			pickupSound.Play();
			GameData.PickItem(item);
			InventoryPanel.Refresh();
			Destroy(gameObject, 1);
			GameData.RemoveCallback(Init);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		canPick = true;
		uiEntry.gameObject.SetActive(canPick);
		Debug.Log(canPick + " itemID" + item.ID);
	}

	private void OnTriggerExit(Collider other)
	{
		canPick = false;
		uiEntry.gameObject.SetActive(canPick);
		Debug.Log(canPick + " itemID" + item.ID);
	}
}
