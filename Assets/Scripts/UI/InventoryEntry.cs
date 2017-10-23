using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class InventoryEntry : MonoBehaviour {

	public Image icon;
	public Text itemName;
	public Text description;
	public Text itemLevel;
	private Button button;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	public void SetItem(InventoryItem item)
	{
		itemName.text = item.name;
		description.text = item.description;
		itemLevel.text = item.level.ToString();
	}

	private void OnClick()
	{
		// Emit event
		Debug.Log("Click");
	}
}

