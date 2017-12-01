using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GamePlayState
{
	Gameplay,
	GameMenu
}

public class GameManager : MonoBehaviour
{
	private static GameManager Instance;

	public static GamePlayState gameState;

	public delegate void InitFunc(bool state);
	public static event InitFunc OnInit;

	public static GameManager Get()
	{
		return Instance;
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this);
			Init();
		}
		else
		{
			Destroy(gameObject);
			Debug.Log("GameManager Instance: " + (Instance == this));
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	private void Init()
	{
		AudioManager.Init();
		GameData.Load();
		SetGameState(GamePlayState.Gameplay);
	}

	private void OnDestroy()
	{

	}

	public static void SetGameState(GamePlayState state)
	{
		gameState = state;
		if (gameState == GamePlayState.GameMenu)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			SceneManager.LoadScene("Scene2");
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			SceneManager.LoadScene("Init");
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			OnInit(true);
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			GameData.Load();
		}

		if (Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log(Application.dataPath);
			Debug.Log(Application.persistentDataPath);
			Debug.Log(Application.streamingAssetsPath);
			GameData.NewGame();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			GameData.Save();
		}

		bool ctrl = Input.GetKey(KeyCode.LeftControl);

		if (Input.GetKeyDown(KeyCode.I))
		{
			if (ctrl)
			{
				Debug.Log("Async loading");
				LevelManager.LoadSceneAsync(0);
			}
			else
			{
				LevelManager.LoadScene(0);
			}
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			if (ctrl)
			{
				Debug.Log("Async loading");
				LevelManager.LoadSceneAsync(1);
			}
			else
			{
				LevelManager.LoadScene(1);
			}
		}
	}

	private void LateUpdate()
	{

	}

	private void FixedUpdate()
	{

	}

	public void OnTriggerEnter(Collider other)
	{

	}

}