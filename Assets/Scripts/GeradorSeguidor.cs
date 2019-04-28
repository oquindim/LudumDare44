using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorSeguidor : MonoBehaviour
{

	public GameObject cubo; // objeto a ser clonado
	public GameObject templo; // objeto a ser clonado
	public float temp = 0;
	public int startX = 3;
	public float frequencia = 1;
	private float lado;
	private float i;
	private float f;

	private void Start()
	{

		f = 1 / frequencia; // inverte para que o input seja mais natural

	}



	// Update is called once per frame
	void Update()
	{

		templo.GetComponent<CapsuleCollider>().radius = Random.Range(3f, 3.5f);
		if (i < f)
		{

			i = i + Time.deltaTime;

		} else {
			Instantiate();
			i = 0;

		}

	}

	void Instantiate () {

		startX = startX * -1;

		Vector3 pos = new Vector3(startX, 0, Random.Range(-3f, 3f));

		GameObject objetoGerado = Instantiate(cubo, pos, Quaternion.identity, transform);

		if (startX < 0) {
			objetoGerado.transform.Rotate(0, -180, 0);
		}

		objetoGerado.SetActive(true);

		Destroy(objetoGerado, 18);


	}
}
