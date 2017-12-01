using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
	private static AsyncOperation loadingInfo;
	public delegate void LoadChange(float value);
	public static event LoadChange OnLoadChange;

	public delegate void LoadStart();
	public static event LoadStart OnLoadStart;

	public static void Init()
	{
	}

	public static IEnumerator Update()
	{
		while(!loadingInfo.isDone)
		{
			Debug.Log(loadingInfo.progress);
			OnLoadChange(loadingInfo.progress);
			yield return new WaitForEndOfFrame();
		}

		OnLoadChange(loadingInfo.progress);
	}

	public static void LoadSceneAsync(int sceneIndex)
	{
		OnLoadStart();
		loadingInfo = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
		GameManager.Get().StartCoroutine(Update());
	}

	public static void LoadScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
	}
}