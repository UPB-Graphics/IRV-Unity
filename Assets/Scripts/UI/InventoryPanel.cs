using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

	public RectTransform rootElement;
	public InventoryEntry itemPrefab;
	private List<InventoryItem> items = new List<InventoryItem>();

	// Use this for initialization
	void Start ()
	{
		// list of InventorItems
		items.Add(new InventoryItem(1, 10, "Sword of...", "Legendary something"));
		items.Add(new InventoryItem(2, 5, "Armor", "ASidgoiasd"));
		items.Add(new InventoryItem(1, 10, "Boots", "Info"));
		items.Add(new InventoryItem(1, 10, "Whatever", "adsfhasdfsdf"));

		Init();
	}

	public void Init()
	{
		foreach (var item in items)
		{
			CreateItemInstance(item);
		}
	}

	private InventoryEntry CreateItemInstance(InventoryItem item)
	{
		var entry = Instantiate(itemPrefab);
		entry.SetItem(item);
		entry.transform.SetParent(rootElement);
		entry.transform.localScale = new Vector3(1, 1, 1);
		return entry;
	}


	// Update is called once per frame
	void Update () {
		
	}
}

