using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraInsatisfeito : MonoBehaviour
{

	public GameObject insatisfeito;
	public GameObject templo;
	private int direcao = 1;


	public void InstantiateInsatisfeito()
	{

		GameObject objetoGerado = Instantiate(insatisfeito, templo.transform.position, Quaternion.identity, transform);
		objetoGerado.transform.position = new Vector3(direcao * 0.1f, objetoGerado.transform.position.y, objetoGerado.transform.position.z);

		if (objetoGerado.transform.position.x < 0)
		{
			objetoGerado.transform.Rotate(0, -180, 0);
		}

		objetoGerado.SetActive(true);
		Destroy(objetoGerado, 40);

		direcao = direcao * -1;

	}
}
