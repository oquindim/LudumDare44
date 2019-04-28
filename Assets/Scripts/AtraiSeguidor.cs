﻿using System.Collections;
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
    public float radiusDecay;

	private int direcao = 1;



    void OnTriggerEnter(Collider other)
    {
        
          GameObject otherObject = other.gameObject;
          otherObject.GetComponent<MoveSeguidor>().atraido = true;
          Debug.Log("entrou");
          objectWithOtherScript.GetComponent<DataController>().remove();

    }

    void ShrinkCollider () {


        float radiusCollider = templo.GetComponent<CapsuleCollider>().radius;

        if (radiusCollider > 0) {
            templo.GetComponent<CapsuleCollider>().radius = radiusCollider - radiusDecay * Time.deltaTime;
        }
        
    }

    public void ReceiveUIInput ( int input ) {
        
        if (input > 0) {
            templo.GetComponent<CapsuleCollider>().radius = input;
        } else {
            DecreaseFollower( input );
        }
    }

    void DecreaseFollower(int input)
    {

        int total = input * -1;

        for (int i = 0; i < total; i++)
        {

            GenerateInsatisfeito();
        }

    }


	void Update()
	{
        ShrinkCollider();
	}


    void GenerateInsatisfeito() {
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
