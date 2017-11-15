using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
	public ParticleSystem particles;
	public float rotateSpeed = 2;

	// Use this for initialization
	void Start ()
	{
	}

	void Update()
	{
		transform.rotation *= Quaternion.Euler(new Vector3(0, rotateSpeed * Mathf.Sin(Time.time), 0));
	}

	private void OnTriggerEnter(Collider other)
	{
		UserResources.CollectCoin();
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<SphereCollider>().enabled = false;
		particles.Play();
		AudioManager.PlaySFX(AudioResources.Instance.collect_coin);
		Destroy(gameObject, particles.main.duration);
	}
}
