using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum AmbientalMusic
{
	SaveSound,
}

public enum BackgroundMusic
{
	Music1,
	Music2,
}

public class AudioResources : MonoBehaviour
{

	public AudioSource collect_coin;
	public AudioSource[] backgroundMusic;
	public AudioSource[] ambientalMusic;

	public static AudioResources Instance;

	void Start()
	{
		Instance = this;
	}
}