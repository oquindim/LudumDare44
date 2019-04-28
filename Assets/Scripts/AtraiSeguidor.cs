using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtraiSeguidor : MonoBehaviour
{
	public int poder;
	public int atraidos = 0;
	private int total;
	public GameObject objectWithOtherScript;
	public GameObject templo;
	public GameObject insatisfeito;

	private int direcao = 1;
	void OnTriggerEnter(Collider other)
	{
		int val = objectWithOtherScript.GetComponent<DataController>().pull;
		if (val > 0 ) {
			GameObject otherObject = other.gameObject;
			otherObject.GetComponent<MoveSeguidor>().atraido = true;
			Debug.Log("entrou");
			atraidos = atraidos + 1;
			objectWithOtherScript.GetComponent<DataController>().remove();
		} else if(val < 0) {

			GameObject objetoGerado = Instantiate(insatisfeito, templo.transform.position, Quaternion.identity, transform);
			objetoGerado.transform.position = new Vector3(direcao * 0.1f, objetoGerado.transform.position.y, objetoGerado.transform.position.z);

			if (objetoGerado.transform.position.x < 0)
			{
				objetoGerado.transform.Rotate(0, -180, 0);
			}

			objetoGerado.SetActive(true);
			Destroy(objetoGerado, 40);

			direcao = direcao * -1;
			objectWithOtherScript.GetComponent<DataController>().add();
		}
	}
}
