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

	private void OnDestroy()
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
		AudioManager.PlaySFX(AudioResources.Instance.collect_coin);

		//Destroy(gameObject, particles.main.duration);

		particles.Play();
		particles.transform.SetParent(transform.parent);

		// Starts a couroutine using the GameManager MonoBehaviour
		Coroutine coroutine = GameManager.Get().StartCoroutine(DestroyParticle(particles.main.duration));

		// Destroy the pickup object
		Destroy(gameObject);
	}

	private IEnumerator ShowMessage(float delay)
	{
		int frames = 0;
		while (frames < 500)
		{
			yield return new WaitForEndOfFrame();
			frames++;
		}

		Debug.Log("Frames: " + frames);
	}

	private IEnumerator DestroyParticle(float delay)
	{
		yield return new WaitForSeconds(delay);
		Debug.Log("Destroy particle");
		Destroy(particles.gameObject);
	}

}
