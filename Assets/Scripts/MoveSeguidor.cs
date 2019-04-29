using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSeguidor : MonoBehaviour
{


	public float velocidade = 2;
	private float direcao = 1;
	public GameObject templo;
	public bool atraido = false;

	// Start is called before the first frame update
	void Start()
	{
		if (transform.position.x > 0) {
			direcao = 1;

		} else {
			direcao = -1;
		}


		velocidade = velocidade * direcao + Random.Range(-0.2f * velocidade, 0.2f * velocidade);
	}

	// Update is called once per frame
	void Update()
	{
		if (atraido) {

			float fatorDist = 1/Vector3.Distance(transform.position, templo.transform.position);

            transform.position = new Vector3 (
                Mathf.Lerp(transform.position.x, templo.transform.position.x, fatorDist * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, templo.transform.position.z, fatorDist * Time.deltaTime)

                ); 


		} else {
			transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime * 0.1f, transform.position.y, transform.position.z);
		}

	}
}

//
