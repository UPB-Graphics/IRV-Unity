using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
		animator.speed = 3;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.tag == "Player")
		{
			animator.SetBool("isOpen", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{

		if (other.tag == "Player")
		{
			animator.SetBool("isOpen", false);
		}
	}

}
