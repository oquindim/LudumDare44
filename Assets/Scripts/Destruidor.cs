using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
	public GameObject objectWithOtherScript;
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		objectWithOtherScript.GetComponent<DataController>().addFollowers(1);
		audio.Play(0);
		Destroy(other.gameObject);
	}
}
