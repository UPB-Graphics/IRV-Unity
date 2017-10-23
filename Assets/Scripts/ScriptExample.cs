using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptExample : MonoBehaviour {

	public int publicVariable;
	private int privateVariable;

	// Use this for initialization
	void Start ()
	{
		GameManager.OnInit += OnInit;
	}

	private void OnInit(bool state)
	{
		Debug.Log("Prefab was initialized after");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
