using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtraiSeguidor : MonoBehaviour
{
	private int total;
	public GameObject objectWithOtherScript;
	public GameObject templo;
	public GameObject insatisfeito;
    public float radiusDecay;
    public float radiusFactor;
	private int direcao = 1;
    public GameObject influenceRadius;
    public float inputRate;



    void OnTriggerEnter(Collider other)
    {
        
          GameObject otherObject = other.gameObject;
          otherObject.GetComponent<MoveSeguidor>().atraido = true;
          objectWithOtherScript.GetComponent<DataController>().remove();

    }

    void ShrinkCollider () {


        float radiusCollider = GetComponent<CapsuleCollider>().radius;

        if (radiusCollider > 0) {
            GetComponent<CapsuleCollider>().radius = radiusCollider - radiusDecay * Time.deltaTime;
        }
        
    }

    public void ReceiveUIInput ( int input ) {
        
        if (input > 0) {
            GetComponent<CapsuleCollider>().radius = GetComponent<CapsuleCollider>().radius + input*inputRate;
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
        InfluenceRadiusSizer();
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

    void InfluenceRadiusSizer() {
        float newscale = GetComponent<CapsuleCollider>().radius * radiusFactor;
        influenceRadius.transform.localScale = new Vector3 (newscale,transform.localScale.y,newscale);
    }

}
