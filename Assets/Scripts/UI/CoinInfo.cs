using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinInfo : MonoBehaviour {

	public Text count;

	// Use this for initialization
	void Start ()
	{
		UpdateInfo();
		UserResources.OnChange += UpdateInfo;
	}

	public void UpdateInfo()
	{
		count.text = UserResources.coins.ToString();
	}
}