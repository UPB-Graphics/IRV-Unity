using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

	private static InventoryPanel Instance;
	public RectTransform rootElement;
	public InventoryEntry itemPrefab;
	private List<InventoryEntry> entries = new List<InventoryEntry>();

	// Use this for initialization
	void Start ()
	{
		Instance = this;
		GameData.OnDataInit(Init);
	}

	public void Init()
	{
		foreach (var entry in entries)
		{
			Destroy(entry.gameObject);
		}
		entries.Clear();

		foreach (var item in GameData.Instance.items)
		{
			var entry = CreateItemInstance(item);
			entries.Add(entry);
		}
	}

	public static void Refresh()
	{
		Instance.Init();
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

