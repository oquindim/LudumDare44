using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
	public GameObject objectWithOtherScript;
	void OnTriggerEnter(Collider other)
	{
		objectWithOtherScript.GetComponent<DataController>().addFollowers(1);
		Destroy(other.gameObject);
	}
}
