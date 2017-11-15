using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
	public GameObject inGameMenu; 
	public enum GameScreen
	{
		InGameMenu
	}

	private void Start()
	{
		inGameMenu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			inGameMenu.SetActive(!inGameMenu.activeInHierarchy);
		}
	}
}