using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {

	public Slider loadingBar;

	// Use this for initialization
	void Start ()
	{
		gameObject.SetActive(false);

		LevelManager.OnLoadStart += () =>
		{
			gameObject.SetActive(true);
		};

		LevelManager.OnLoadChange += ((float value) =>
		{
			loadingBar.value = value;
			if (value == 1)
			{
				gameObject.SetActive(false);
			}
		});
	}
}